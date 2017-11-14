using World.WorldUtils;
using UnityEngine;

namespace World {
    namespace WorldTiles {
        public class StructureTile : Tile {
            public StructureTile(CoordinatePair coordinatePair) : base(coordinatePair, 2) {

            }
            override protected GameObject getTileForInstantiate() {
                return StaticWorldObjects.getInitStructureTile();
            }
        }
    }
}