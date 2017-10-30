using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour, IF_Pickable, IF_Storeable {

    [SerializeField]
    private string ResourceName;

    private float Amount;
    private IF_CanPickup Owner;
    


    public void DropDown() {
        Owner = null;
        //TODO: Create prefab on the ground or something
    }

    public void PickUp(IF_CanPickup owner) {
        Owner = owner;
        owner.PickUp(this);
    }

    public void Store(IF_CanStore what) {
        Owner = null;
        what.Store(this);
    }
}
