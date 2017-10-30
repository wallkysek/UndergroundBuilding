using UnityEngine;

public class UndestructibleTile : MonoBehaviour
{
    [SerializeField]
    private int minx;
    [SerializeField]
    private int miny;
    [SerializeField]
    private int maxx;
    [SerializeField]
    private int maxy;

    public bool isDestructible(int x, int y)
    {
        return (minx <= x && x <= maxx && miny <= y && y <= maxy);
    }

    public void Start() {
        this.enabled = false; //no update function needed
    }
}
