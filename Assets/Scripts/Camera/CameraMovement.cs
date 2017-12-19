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
        this.gameObject.transform.position += (new Vector3(MovementVector.x, MovementVector.y, 0) * Time.deltaTime);
        Vector3 finalCamPos = this.gameObject.transform.position;

        float leftCameraEdge = mCam.ScreenToWorldPoint(new Vector3(0, 0, 4)).x    ;
        float rightCameraEdge = mCam.ScreenToWorldPoint(new Vector3(mCam.pixelWidth, 0, 4)).x;
        float topCameraEdge = mCam.ScreenToWorldPoint(new Vector3(0, mCam.pixelHeight, 4)).y;
        float bottomCameraEdge = mCam.ScreenToWorldPoint(new Vector3(0, 0, 4)).y;

        Vector3 centerPos = mCam.ScreenToWorldPoint(new Vector3(mCam.pixelWidth / 2, mCam.pixelHeight / 2, 4));

        if ((rightCameraEdge + rightPadding) > UndestructableTile.getMaxx()) {
            finalCamPos.x = centerPos.x - Mathf.Abs((rightCameraEdge + rightPadding) - UndestructableTile.getMaxx());
        }
        if ((leftCameraEdge - leftPadding) < UndestructableTile.getMinx()) {
            finalCamPos.x = centerPos.x + Mathf.Abs((leftCameraEdge - leftPadding) - UndestructableTile.getMinx());
        }

        if (-(topCameraEdge + topPadding) < UndestructableTile.getMiny()) {
            finalCamPos.y = centerPos.y - Mathf.Abs((topCameraEdge + topPadding) - UndestructableTile.getMiny());
        }

        if (-(bottomCameraEdge - bottomPadding) > UndestructableTile.getMaxy()) {
            finalCamPos.y = centerPos.y + Mathf.Abs((bottomCameraEdge - bottomPadding) + UndestructableTile.getMaxy());
        }
        this.gameObject.transform.position = finalCamPos;

    }
}
