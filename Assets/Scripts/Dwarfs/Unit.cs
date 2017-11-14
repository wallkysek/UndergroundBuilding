using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour {
    [SerializeField]
    protected List<Action> Actions = new List<Action>();

    void Start() {
        this.enabled = false;    
    }
}
