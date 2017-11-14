using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class Action : MonoBehaviour {
    public abstract void Do(ref object actor, ref object target);

    [SerializeField]
    private string Name = "Action";

    void Start() {
        this.enabled = false;    
    }
    private void Select() { 
                
    }
}
