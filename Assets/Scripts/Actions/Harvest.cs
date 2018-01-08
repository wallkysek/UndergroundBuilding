using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvest : Actions.Action {
    public override void Do(object actor, object target) {
        if (!(actor is IF_CanHarvest)) {
            throw new ActionException("This unit doesn't know how to harvest this");
        }
        if (!(target is IF_Harvestable)) {
            throw new ActionException("This thing can't be harvested");
        }
        ((IF_CanHarvest)actor).Harvest((IF_Harvestable)target);
    }
}
