using World.WorldUtils;
using UnityEngine;

namespace World {
    namespace WorldTiles {
        public class StructureTile : Tile {
            override protected GameObject getTileForInstantiate() {
                return StaticWorldObjects.getInitStructureTile();
            }
        }
    }
}