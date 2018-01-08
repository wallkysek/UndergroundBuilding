using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.WorldTiles;
using World.WorldUtils;
using World;

public class WorlInitialize : MonoBehaviour {

    [SerializeField]
    private GameObject WorldTile;
    [SerializeField]
    private GameObject StructureTile;
    [SerializeField]
    private GameObject BackGroundTile;
    [SerializeField]
    private Material goldMaterial;
    [SerializeField] 
    private GameObject resourceDrop;

    [SerializeField]
    private int PaddingLeft = 5;
    [SerializeField]
    private int PaddingRight = 5;
    [SerializeField]
    private int PaddingTop = 0;
    [SerializeField]
    private int PaddingBottom = 5;


    // Use this for initialization
    void Start() {
        ProceduralNoise generator = gameObject.GetComponent<ProceduralNoise>();
        int minX = UndestructableTile.getMinx() - PaddingLeft;
        int maxX = UndestructableTile.getMaxx() + PaddingRight;
        int minY = UndestructableTile.getMiny() - PaddingTop;
        int maxY = UndestructableTile.getMaxy() + PaddingBottom;

        int sizeX = Mathf.Abs(minX) + Mathf.Abs(maxX)+1;
        int sizeY = Mathf.Abs(minY) + Mathf.Abs(maxY)+1;

        int[,] goldenNoise = generator.GenerateNoise(sizeX,sizeY,0f,0f,0.001f,0.8f);
        int[,] tunnelNoise = generator.GenerateNoise(sizeX, sizeY, 1f, 1f, 0.08f, 0.7f);
        for(int i = minX; i < maxX; i++) {
            for(int j = minY; j < maxY; j++) {
                    GameObject Instantiated = Instantiate(WorldTile);
                    if (goldenNoise[i + Mathf.Abs(minX), j + Mathf.Abs(minY)] == 1) {
                        Renderer rendererInstantiated = Instantiated.GetComponent<Renderer>();
                        rendererInstantiated.material = goldMaterial;
                        Instantiated.GetComponent<WorldTile>().setResource(resourceDrop);
                    }
                


                    Tile inTile = Instantiated.GetComponent<WorldTile>();

                if (tunnelNoise[i + Mathf.Abs(minX), j + Mathf.Abs(minY)] == 0) {
                    if (inTile != null) {
                        inTile.InitiateTile(CoordinatePair.Init(i, j));
                        StaticWorldObjects.WorldTiles.Add(CoordinatePair.Init(i, j), (WorldTile)inTile);
                    }
                }
                    Instantiated = Instantiate(StructureTile);
                    inTile = Instantiated.GetComponent<StructureTile>();
                    if (inTile != null) {
                        inTile.InitiateTile(CoordinatePair.Init(i, j));
                        StaticWorldObjects.WorldStructureTiles.Add(CoordinatePair.Init(i, j), (StructureTile)inTile);
                    }
                    Instantiated = Instantiate(BackGroundTile);
                    inTile = Instantiated.GetComponent<WorldBackgroundTile>();
                    if (inTile != null) {
                        inTile.InitiateTile(CoordinatePair.Init(i, j));
                        StaticWorldObjects.WorldBackgroundTiles.Add(CoordinatePair.Init(i, j), (WorldBackgroundTile)inTile);
                    }
                }
            
        }

        this.enabled = false;
    }
}
