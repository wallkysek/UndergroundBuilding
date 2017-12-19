using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureRooms : MonoBehaviour
{
    public ArrayList getRadnomRooms(int count, int sizeMin, int sizeMax)
    {
        ArrayList array = new ArrayList();

        int minx = UndestructableTile.getMinx();
        int miny = UndestructableTile.getMiny();
        int maxx = UndestructableTile.getMaxx();
        int maxy = UndestructableTile.getMaxy();

        for (int i = 0;i < count; i++)
        {
            System.Random rnd = new System.Random();
            int randomx = rnd.Next(minx, maxx);
            array.Add(randomx);
            System.Random rnd2 = new System.Random();
            int randomy = rnd2.Next(miny, maxy);
            array.Add(randomy);

            System.Random rnd3 = new System.Random();
            int sizex = rnd3.Next(sizeMin, sizeMax);
            array.Add(sizex);

            System.Random rnd4 = new System.Random();
            int sizey = rnd4.Next(sizeMin, sizeMax);
            array.Add(sizey);
        }

        return array;
    }

	// Use this for initialization
	void Start ()
    {
        this.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
