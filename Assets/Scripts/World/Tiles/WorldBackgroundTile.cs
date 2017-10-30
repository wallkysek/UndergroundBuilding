using World.WorldUtils;
using UnityEngine;

namespace World {
    namespace WorldTiles {
        public class WorldBackgroundTile : Tile {
            public WorldBackgroundTile(CoordinatePair coordinatePair) : base(coordinatePair,2) {
            }
            override protected GameObject getTileForInstantiate() {
                return StaticWorldObjects.getInitBackgroundTile();
            }
        }
    }
}