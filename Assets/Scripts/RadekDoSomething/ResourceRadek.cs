using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceRadek : MonoBehaviour, IPickable<GameObject>, IStorable, IHarvestable, IOwnable<GameObject> {
    public enum State {
        NONE = 0,
        NODE = 1,
        PICKUP = 2,
        PICKED = 3,
        STORED = 4
    }
    
    public Mesh nodeMesh;
    public Mesh pickUpMesh;
    protected State state = State.NONE;
    protected GameObject owner;
    protected MeshFilter meshFilter;


    void Start() {
        meshFilter = GetComponent<MeshFilter>();
        this.ChangeMesh();
    }

    public void PickUp(GameObject owner) {
        if((this.state == State.PICKUP)||(this.state == State.STORED)) {
            this.state = State.PICKED;
            this.owner = owner;
            this.ChangeMesh();
        }
    }

    public void PutDown() {
        if(this.state == State.PICKED) {
            this.state = State.PICKUP;
            this.ChangeMesh();
        }
    }

    public void Harvest() {
        if(this.state == State.NODE) {
            this.state = State.PICKUP;
            this.ChangeMesh();
            //TODO: change transform.position? || set gravity? 
        }
    }

    protected void ChangeMesh() {
        switch (state) {
            case State.NONE:
                gameObject.SetActive(false);
                break;
            case State.NODE:
                gameObject.SetActive(true);
                this.meshFilter.mesh = nodeMesh;
                break;
            case State.PICKUP:
                gameObject.SetActive(true);
                this.meshFilter.mesh = pickUpMesh;
                break;
            case State.PICKED:
                gameObject.SetActive(false);
                break;
            case State.STORED:
                gameObject.SetActive(true);
                this.meshFilter.mesh = pickUpMesh;
                break;
        }
    }

    public void Store() {
        if(this.state == State.PICKED) {
            this.state = State.STORED;
            this.RemoveOwner();
            this.ChangeMesh();
        }
    }

    public void SetOwner(GameObject owner) {
        this.owner = owner;
    }

    public GameObject GetOwner() {
        return this.owner;
    }

    public void RemoveOwner() {
        this.owner = gameObject;
    }
}
