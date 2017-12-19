using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Resource : MonoBehaviour, IF_Pickable, IF_Storeable {


    [SerializeField]
    private string ResourceName;
    private IF_CanPickup owner;

    void Start() {
    }

    public void DropDown() {
        owner = null;
        //TODO: Create prefab on the ground or something
    }

    

    public void PickUp(IF_CanPickup owner) {
        this.owner = owner;
        owner.PickUp(this);
        gameObject.SetActive(false);
    }

    public void Store(IF_CanStore what) {
        owner = null;
        what.Store(this);
    }
    

    
}
