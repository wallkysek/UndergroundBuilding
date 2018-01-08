using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : Actions.Action {

    [SerializeField]
    private List<Prebuild> buildableList = new List<Prebuild>();
    
    public override void Do(object actor, object target) {
        //TODO: implement building
    }

    public List<Prebuild> BuildableList
    {
        get { return buildableList; }
    }
}
