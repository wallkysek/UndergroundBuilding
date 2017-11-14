using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dwarf : Unit, IF_CanDestroy, IF_Selectable {
    public void Destroy() {
        throw new NotImplementedException();
    }

    public List<Action> GetActionList() {
        return Actions;
    }
}
