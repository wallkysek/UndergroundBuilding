using World.WorldUtils;
using UnityEngine;

namespace World {
    namespace WorldTiles {
        public class WorldBackgroundTile : Tile {
            public WorldBackgroundTile(CoordinatePair coordinatePair) : base(coordinatePair,4) {
            }
            override protected GameObject getTileForInstantiate() {
                return StaticWorldObjects.getInitBackgroundTile();
            }
        }
    }
}