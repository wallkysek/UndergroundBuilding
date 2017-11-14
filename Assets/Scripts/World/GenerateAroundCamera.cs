using System.Collections;
using System.Collections.Generic;
using World;
using World.WorldUtils;
using World.WorldTiles;
using UnityEngine;

public class GenerateAroundCamera : MonoBehaviour {

    [SerializeField]
    private int generatingRange = 8;
    [SerializeField]
    private int hidingRange = 5;    //need disable in range generatingRange+hidingRange
    [SerializeField]
    private GameObject playerGO;
    private Camera playerCam;


    // Use this for initialization
    void Start () {
        playerCam = playerGO.GetComponent<Camera>();
        if (playerCam == null) {
            throw new System.Exception("No playerCam attached");
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 CameraPosition = playerCam.ScreenToWorldPoint(new Vector3(playerCam.pixelWidth / 2, playerCam.pixelHeight / 2, 10));
        CameraPosition = new Vector3((int)CameraPosition.x, (int)CameraPosition.y, 10);
        for(int i = -generatingRange-hidingRange+1; i < generatingRange+hidingRange; i++) {
            for (int j = -generatingRange-hidingRange + 1; j < generatingRange+hidingRange; j++) {
                if (CameraPosition.y + j > 0) continue;
                if (!StaticWorldObjects.WorldBackgroundTiles.ContainsKey(CoordinatePair.Init((int)CameraPosition.x + i, -((int)CameraPosition.y + j)))) {
                    //Not found, add to the list
                    StaticWorldObjects.WorldBackgroundTiles.Add(CoordinatePair.Init((int)CameraPosition.x + i, -((int)CameraPosition.y + j)),
                        new WorldBackgroundTile(CoordinatePair.Init((int)CameraPosition.x + i, -((int)CameraPosition.y + j))));
                    StaticWorldObjects.WorldStructureTiles.Add(CoordinatePair.Init((int)CameraPosition.x + i, -((int)CameraPosition.y + j)),
                        new StructureTile(CoordinatePair.Init((int)CameraPosition.x + i, -((int)CameraPosition.y + j))));
                    StaticWorldObjects.WorldTiles.Add(CoordinatePair.Init((int)CameraPosition.x + i, -((int)CameraPosition.y + j)),
                        new WorldTile(CoordinatePair.Init((int)CameraPosition.x + i, -((int)CameraPosition.y + j))));
                }
                Vector3 TilePos = StaticWorldObjects.WorldBackgroundTiles[CoordinatePair.Init((int)CameraPosition.x + i, -((int)CameraPosition.y + j))].getPosition();
                if (Vector2.Distance(new Vector2(CameraPosition.x, CameraPosition.y),
                    new Vector2(TilePos.x, TilePos.y)) > generatingRange) {
                    //Hide
                    StaticWorldObjects.WorldBackgroundTiles[CoordinatePair.Init((int)CameraPosition.x + i, -((int)CameraPosition.y + j))].HideTile();
                    StaticWorldObjects.WorldStructureTiles[CoordinatePair.Init((int)CameraPosition.x + i, -((int)CameraPosition.y + j))].HideTile();
                    StaticWorldObjects.WorldTiles[CoordinatePair.Init((int)CameraPosition.x + i, -((int)CameraPosition.y + j))].HideTile();
                } else {
                    //Show
                    StaticWorldObjects.WorldBackgroundTiles[CoordinatePair.Init((int)CameraPosition.x + i, -((int)CameraPosition.y + j))].ShowTile();
                    StaticWorldObjects.WorldStructureTiles[CoordinatePair.Init((int)CameraPosition.x + i, -((int)CameraPosition.y + j))].ShowTile();
                    StaticWorldObjects.WorldTiles[CoordinatePair.Init((int)CameraPosition.x + i, -((int)CameraPosition.y + j))].ShowTile();
                }

            }
        }
	}
}
