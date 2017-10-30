using World.WorldUtils;
using UnityEngine;

namespace World {
    namespace WorldTiles {
        public class WorldTile : Tile {
            public WorldTile(CoordinatePair coordinatePair) : base(coordinatePair,0) {
            }
            override protected GameObject getTileForInstantiate() {
                return StaticWorldObjects.getInitWorldTile();
            }
        }
    }
}