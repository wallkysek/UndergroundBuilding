using UnityEngine;

public class UndestructableTile : MonoBehaviour
{

    [SerializeField]
    private int minx = 0;
    [SerializeField]
    private int miny = 0;
    [SerializeField]
    private int maxx = 0;
    [SerializeField]
    private int maxy = 0;

    static private int sminx = -20;
    static private int sminy = 0;
    static private int smaxx = 20;
    static private int smaxy = 40;

    public bool IsDestructable(int x, int y)
    {
        return (minx <= x && x <= maxx && miny <= y && y <= maxy);
    }

    public void Start()
    {
        this.enabled = false; //no update function needed
        /*sminx = minx;
        sminy = miny;
        smaxx = maxx;
        smaxy = maxy;*/
        minx = sminx;
        miny = sminy;
        maxx = smaxx;
        maxy = smaxy;
    }

    public static int getMinx() {
        return sminx;
    }
    public static int getMiny() {
        return sminy;
    }
    public static int getMaxx() {
        return smaxx;
    }
    public static int getMaxy() {
        return smaxy;
    }
}
