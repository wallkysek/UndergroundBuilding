using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : Action {
    public override void Do(object actor, object target) {
        if(!(actor is IF_CanDestroy)) {
            //TODO: Exception Invalid Action
        }
        if(!(target is IF_Destroyable)) {
            //TODO: Exception Invalid Action
        }
        IF_CanDestroy Actor = actor as IF_CanDestroy;
        Actor.Destroy(target as IF_Destroyable);
    }

    public void Update() {
        Debug.Log("ewqewq");
    }
}
