using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : Action {
    public override void Do(ref object actor, ref object target) {
        if(!(actor is IF_CanDestroy)) {
            //TODO: Exception Invalid Action
        }
        if(!(target is IF_Destroyable)) {
            //TODO: Exception Invalid Action
        }
        throw new NotImplementedException();
    }
}
