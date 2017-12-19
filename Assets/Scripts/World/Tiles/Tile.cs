using System.Collections;
using System.Collections.Generic;
using World.WorldUtils;
using UnityEngine;

namespace World {
    namespace WorldTiles {
        public class Tile : UnityEngine.MonoBehaviour {
            [SerializeField]
            protected int layer = -1;
            private Vector3 position = new Vector3(0, 0, 0);
            public bool isActive = false;
            private bool isDestroyed = false;
            private bool isDestructible = true;

            private CoordinatePair Coordinates;

            public virtual void InitiateTile(CoordinatePair coordinatePair) {
                this.Coordinates = coordinatePair;
                this.position = new Vector3(this.Coordinates.X, -this.Coordinates.Y, this.layer);
                this.gameObject.transform.position = this.position;
            }
            public Vector3 getPosition() {
                return this.position;
            }
            public CoordinatePair GetCoordinates() {
                return this.Coordinates;
            }

            protected virtual GameObject getTileForInstantiate() {
                throw new System.Exception("Method getTileForInstantiate not implemented");
            }
            public void DestroyTile() {
                if (!isDestructible)
                    return;
                GameObject.Destroy(this.gameObject);

            }
           
        }
    }
}