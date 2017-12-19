using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {

    [SerializeField]
    private float Min = -6;
    [SerializeField]
    private float Max = -1;
    [SerializeField][Range(1, 10)]
    private float Speed = 1;
    // Use this for initialization
    void Start () {
	}

    private void Update() {
        float WheelDelta = Input.GetAxis("Mouse ScrollWheel");
        
        Vector3 TransformVec = Vector3.forward * WheelDelta * Speed;
        this.gameObject.transform.position += TransformVec;
        Vector3 PosVes = this.gameObject.transform.position;

        if (this.gameObject.transform.position.z > Max) {
            PosVes.z = Max;
        } else if(this.gameObject.transform.position.z < Min) {
            PosVes.z = Min;
        }
        this.gameObject.transform.position = PosVes;
    }
}
