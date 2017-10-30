using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    [SerializeField]
    private float CameraSpeed = 1.0f;
    private Vector2 MovementVector;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
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
    }
}
