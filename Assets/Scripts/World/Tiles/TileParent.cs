﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.WorldTiles;

public class TileParent : MonoBehaviour, IF_Selectable {

    private Tile parent;

	// Use this for initialization
	void Start () {
        this.enabled = false;   //Dont need update functions for this one
	}

    public Tile GetParent() {
        return this.parent;
    }
    public void Setparent(Tile parent) {
        this.parent = parent;
    }

    public List<Actions.Action> GetActionList() {
        return new List<Actions.Action>();
    }

    public IF_Selectable GetTarget() {
        if(parent is IF_Selectable) {
            return this.parent as IF_Selectable;
        } else {
            throw new System.Exception("Selected nonselectable!");  
        }
    }
}
