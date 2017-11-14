using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Resource : MonoBehaviour, IF_Pickable, IF_Storeable, IF_Harvestable {


    [SerializeField]
    private string ResourceName;

    private Mesh nodeMesh;
    private Mesh pickUpMesh;
    private float amount;
    private IF_CanPickup owner;
    protected MeshFilter meshFilter;

    void Start() {
        meshFilter = GetComponent<MeshFilter>();
        this.ChangeMesh();
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

    public void Harvest(IF_CanHarvest harvester) {
        harvester.Harvest(this);
        this.ChangeMesh();
    }

    public void ChangeMesh() {
        this.meshFilter.mesh = pickUpMesh;
    }
}
