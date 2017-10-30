using System.Collections;
using System.Collections.Generic;
using World.WorldUtils;
using UnityEngine;

namespace World {
    namespace WorldTiles {
        public class Tile {
            protected int layer = -1;
            private readonly Vector3 position = new Vector3(0, 0, 0);
            public bool isActive = false;
            private bool isDestroyed = false;
            private bool isDestructible = true;
            public GameObject assignedTile;

            private CoordinatePair Coordinates;

            public Tile(CoordinatePair coordinatePair, int layer) {
                this.Coordinates = coordinatePair;
                this.layer = layer;
                this.position = new Vector3(this.Coordinates.X, -this.Coordinates.Y, this.layer);
            }
            public Vector3 getPosition() {
                return this.position;
            }
            public CoordinatePair GetCoordinates() {
                return this.Coordinates;
            }
            public void HideTile() {
                if(this.assignedTile != null && isActive != false) {
                    this.assignedTile.GetComponent<TileParent>().Setparent(null);
                    GameObject.Destroy(this.assignedTile);
                    isActive = false;
                }
            }
            protected virtual GameObject getTileForInstantiate() {
                throw new System.Exception("Method getTileForInstantiate not implemented");
            }
            public void DestroyTile() {
                if (!isDestructible)
                    return;
                this.isDestroyed = true;
                this.HideTile();
            }
            public void ShowTile() {
                if (!this.isActive) {
                    if (isDestroyed)
                        return;
                    this.assignedTile = GameObject.Instantiate(this.getTileForInstantiate(),
                            this.position,
                            new Quaternion());
                    this.assignedTile.GetComponent<TileParent>().Setparent(this);
                    isActive = true;
                }
            }
        }
    }
}