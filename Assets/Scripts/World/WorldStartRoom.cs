using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.WorldUtils;

public class WorldStartRoom : MonoBehaviour {
    [System.Serializable]
    private struct Buildings {
        [SerializeField]
        public GameObject building;
        [SerializeField]
        public int positionX;
        [SerializeField]
        public int positionY;
    }

    [System.Serializable]
    private struct Rooms {
        [SerializeField]
        public int positionX;
        [SerializeField]
        public int positionY;
        [SerializeField]
        public int sizeX;
        [SerializeField]
        public int sizeY;
    }

    [System.Serializable]
    private struct Tunnels {
        [SerializeField]
        public int positionX;
        [SerializeField]
        public int positionY;
        [SerializeField]
        public int size;
        [SerializeField]
        public bool horizontalOrientation;
        [SerializeField]
        public bool positiveOrientation;
    }
    
    private const int positionZOffset = 1;

    [SerializeField]
    private Buildings[] buildings;

    [SerializeField]
    private Rooms[] rooms;

    [SerializeField]
    private Tunnels[] tunnels;

  
    
    void FixedUpdate() {
        for(int i = 0; i < rooms.Length; i++) {
            for (int ix = 0; ix < rooms[i].sizeX; ix++) {
                for (int iy = 0; iy < rooms[i].sizeY; iy++) {
                    WorldStartPoint tunnelPoint = gameObject.AddComponent<WorldStartPoint>();
                    tunnelPoint.SetStartPoint(rooms[i].positionX + ix, rooms[i].positionY - iy, World.WorldUtils.TileType.TILE_WORLD);
                    WorldStartPoint roomPoint = gameObject.AddComponent<WorldStartPoint>();
                    roomPoint.SetStartPoint(rooms[i].positionX + ix, rooms[i].positionY - iy, World.WorldUtils.TileType.TILE_STRUCTURE);
                }
            }
        }

        for(int i =0; i< buildings.Length; i++) {
            Instantiate(buildings[i].building, new Vector3(buildings[i].positionX, -buildings[i].positionY, positionZOffset), transform.rotation);
        }

        for(int i=0; i< tunnels.Length; i++) {
            for(int j=0; j < tunnels[i].size; j++) {
                WorldStartPoint tunnelPoint = gameObject.AddComponent<WorldStartPoint>();
                int increment = j;
                if (!tunnels[i].positiveOrientation)
                    increment = -increment;
                if (tunnels[i].horizontalOrientation)
                    tunnelPoint.SetStartPoint(tunnels[i].positionX + increment, tunnels[i].positionY, World.WorldUtils.TileType.TILE_WORLD);
                else
                    tunnelPoint.SetStartPoint(tunnels[i].positionX, tunnels[i].positionY + increment, World.WorldUtils.TileType.TILE_WORLD);

            }
        }
        this.enabled = false;
        Destroy(this);
    }

    public CoordinatePair GetDefaultBuildingPosition() {
        if (buildings.Length > 0) {
            return CoordinatePair.Init(buildings[0].positionX, buildings[0].positionY);
        }
        else {
            return CoordinatePair.Init(0, 0);
        }
    }
}
