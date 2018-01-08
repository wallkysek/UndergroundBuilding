using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour {
    [SerializeField]
    protected List<Actions.Action> Actions = new List<Actions.Action>();
    [SerializeField]

    void Start() {
        this.enabled = false;    
    }
}
