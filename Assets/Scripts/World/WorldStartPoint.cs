using UnityEngine;
using World;
using World.WorldUtils;

public class WorldStartPoint : MonoBehaviour {

    [SerializeField]
    private int X;
    [SerializeField]
    private int Y;
    [SerializeField]
    private TileType TileType;

    void FixedUpdate() {
        switch (TileType){
            case TileType.TILE_WORLD:
                if (!StaticWorldObjects.WorldTiles.ContainsKey(CoordinatePair.Init(X, Y)))
                    return;
                StaticWorldObjects.WorldTiles[CoordinatePair.Init(X, Y)].DestroyTile();
                this.enabled = false;
                Destroy(this);
                break;
            case TileType.TILE_STRUCTURE:
                if (!StaticWorldObjects.WorldStructureTiles.ContainsKey(CoordinatePair.Init(X, Y)))
                    return;
                StaticWorldObjects.WorldStructureTiles[CoordinatePair.Init(X, Y)].DestroyTile();
                this.enabled = false;
                Destroy(this);
                break;
            default:
                break;
        }
    }

    public void SetStartPoint(int x, int y, TileType tileType) {
        this.X = x;
        this.Y = y;
        this.TileType = tileType;
    }
}
