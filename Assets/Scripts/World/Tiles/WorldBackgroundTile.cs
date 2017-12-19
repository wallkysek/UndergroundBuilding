using World.WorldUtils;
using UnityEngine;

namespace World {
    namespace WorldTiles {
        public class WorldBackgroundTile : Tile {

            override protected GameObject getTileForInstantiate() {
                return StaticWorldObjects.getInitBackgroundTile();
            }
        }
    }
}