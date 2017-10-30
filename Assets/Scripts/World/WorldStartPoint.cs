using UnityEngine;
using World;
using World.WorldUtils;

public class WorldStartPoint : MonoBehaviour {

    [SerializeField]
    private int X;
    [SerializeField]
    private int Y;

    void FixedUpdate() {
        if (!StaticWorldObjects.WorldTiles.ContainsKey(CoordinatePair.Init(X, Y)))
            return;
        StaticWorldObjects.WorldTiles[CoordinatePair.Init(X, Y)].DestroyTile();
        this.enabled = false;
    }
}
