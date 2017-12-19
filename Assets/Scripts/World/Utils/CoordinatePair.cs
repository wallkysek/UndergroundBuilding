namespace World {
    namespace WorldUtils {
        public struct CoordinatePair {
            public int X;
            public int Y;
            public static CoordinatePair Init(int x, int y) {
                CoordinatePair pair;
                pair.X = x;
                pair.Y = y;
                return pair;
            }
        };
        public enum TileType {
            TILE_WORLD,
            TILE_STRUCTURE,
            TILE_BACKGROUND
        };
    }
}