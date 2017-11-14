using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    [SerializeField]
    private float CameraSpeed = 1.0f;
    [SerializeField]
    private int leftPadding;
    [SerializeField]
    private int rightPadding;
    [SerializeField]
    private int topPadding;
    [SerializeField]
    private int bottomPadding;
    private Vector2 MovementVector;
    private Camera mCam;

	// Use this for initialization
	void Start () {
        this.mCam = this.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 initialCamPos = this.gameObject.transform.position;
        
        this.MovementVector = new Vector2(0, 0);
        if (TriggerState.BottomTriggered)
            MovementVector.y = -1 * this.CameraSpeed;
        if (TriggerState.TopTriggered && this.transform.position.y < 1)
            MovementVector.y = 1 * this.CameraSpeed;
        if (TriggerState.LeftTriggered)
            MovementVector.x = -1 * this.CameraSpeed;
        if (TriggerState.RightTriggered)
            MovementVector.x = 1 * this.CameraSpeed;
        this.gameObject.transform.position += new Vector3(MovementVector.x, MovementVector.y, 0);
        Vector3 finalCamPos = this.gameObject.transform.position;

        float leftCameraEdge = mCam.ScreenToWorldPoint(new Vector3(0, 0, 4)).x    ;
        float rightCameraEdge = mCam.ScreenToWorldPoint(new Vector3(mCam.pixelWidth, 0, 4)).x;
        float topCameraEdge = mCam.ScreenToWorldPoint(new Vector3(0, mCam.pixelHeight, 4)).y;
        float bottomCameraEdge = mCam.ScreenToWorldPoint(new Vector3(0, 0, 4)).y;

        if ((rightCameraEdge + rightPadding) > UndestructableTile.getMaxx()) {
            finalCamPos.x = initialCamPos.x;
        }
        if ((leftCameraEdge - leftPadding) < UndestructableTile.getMinx()) {
            finalCamPos.x = initialCamPos.x;
        }

        if (-(topCameraEdge + topPadding) < UndestructableTile.getMiny()) {
            finalCamPos.y = initialCamPos.y;
        }

        if (-(bottomCameraEdge - bottomPadding) > UndestructableTile.getMaxy()) {
            finalCamPos.y = initialCamPos.y;
        }
        this.gameObject.transform.position = finalCamPos;

    }
}
