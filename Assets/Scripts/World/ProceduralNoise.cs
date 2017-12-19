using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralNoise : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int[,] GenerateNoise(int xMax, int yMax, float xOff, float yOff, float scaleFactor, float rule ) {
        int[,] noise = new int[xMax, yMax];
        for (int y = 0; y < yMax; y++) {
            for (int x = 0; x < xMax; x++) {
                float result = Mathf.PerlinNoise(xOff / scaleFactor + (float)(x / (xMax * scaleFactor)), yOff / scaleFactor + (float)(y / (yMax * scaleFactor)));
                if (result >= rule)
                    noise[x, y] = 1;
                else
                    noise[x, y] = 0;
                
            }
        }

        return noise;
    }
}
