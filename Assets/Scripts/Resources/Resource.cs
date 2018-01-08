using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Resource : MonoBehaviour, IF_Pickable, IF_Storeable, IF_Harvestable, IF_Target, IPointerDownHandler {


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


    virtual public void Harvest()
    {
        
    }

    public Vector3 GetTargetPosition()
    {
        return this.gameObject.transform.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ClickModeManager.GetInstance().ClickedOnGO(this.gameObject);
    }
}
