using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.WorldUtils;

public class CameraStart : MonoBehaviour
{

    [SerializeField]
    private Camera PlayerCam;
    private Vector3 finalPos;

	// Use this for initialization
	void Start () {
        WorldStartRoom worldStartRoom = gameObject.GetComponent<WorldStartRoom>();
        CoordinatePair pos = worldStartRoom.GetDefaultBuildingPosition();
        finalPos = new Vector3(pos.X, -pos.Y + 2, -5);
        this.CenterCamera();

        this.enabled = false;
    }
	
    public void CenterCamera() {
        PlayerCam.transform.position = finalPos;
    }

	// Update is called once per frame
	void Update ()
    {
		
	}
}
