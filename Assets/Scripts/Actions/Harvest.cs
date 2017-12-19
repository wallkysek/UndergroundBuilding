using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvest : Action {
    public override void Do(object actor, object target) {
        if (!(actor is IF_CanHarvest)) {
            //TODO: Exception Invalid Action
        }
        if (!(target is IF_Harvestable)) {
            //TODO: Exception Invalid Action
        }
        ((IF_CanHarvest)actor).Harvest((IF_Harvestable)target);
        ((IF_Harvestable)target).Harvest((IF_CanHarvest)actor);
    }
}
