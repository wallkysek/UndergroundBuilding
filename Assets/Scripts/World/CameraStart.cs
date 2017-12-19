using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.WorldUtils;

public class CameraStart : MonoBehaviour
{

    [SerializeField]
    private Camera PlayerCam;

	// Use this for initialization
	void Start ()
    {
        WorldStartRoom worldStartRoom = gameObject.GetComponent<WorldStartRoom>();
        CoordinatePair pos = worldStartRoom.GetDefaultBuildingPosition();

        Vector3 finalPos = new Vector3(pos.X, -pos.Y+2, -5);



        //int newx = pos.X;
        //int newy = pos.Y;
        
        //int minx = UndestructableTile.getMinx() + PlayerCam.pixelHeight / 2;
        //int miny = UndestructableTile.getMiny() + PlayerCam.pixelWidth / 2;
        //int maxx = UndestructableTile.getMaxx() - PlayerCam.pixelHeight / 2;
        //int maxy = UndestructableTile.getMaxy() - PlayerCam.pixelWidth / 2;

        //if (newx < minx) newx = minx;
        //if (newx > maxx) newx = maxx;
        //if (newy < miny) newy = miny;
        //if (newy > maxy) newy = maxy;

        PlayerCam.transform.position = finalPos;

        this.enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
