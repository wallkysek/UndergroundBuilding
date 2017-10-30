using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.WorldTiles;

public class TileParent : MonoBehaviour {

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
}
