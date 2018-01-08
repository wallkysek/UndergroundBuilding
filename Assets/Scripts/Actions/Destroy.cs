using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : Actions.Action {
    public override void Do(object actor, object target) {
        if(!(actor is IF_CanDestroy)) {
            throw new ActionException("This unit doesn't know how to destroy anything");
        }
        if(!(target is IF_Destroyable)) {
            throw new ActionException("This thing can't be destroyed");
        }
        IF_CanDestroy Actor = actor as IF_CanDestroy;
        Actor.Destroy(target as IF_Destroyable);
    }
}
