using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour {
    enum TriggerPosition { LEFT, RIGHT, TOP, BOTTOM };


    [SerializeField]
    private TriggerPosition TrigPos;
    [SerializeField]
    private float TrigSize;

    private Camera PlayerCam;

    void Start() {
        PlayerCam = gameObject.transform.root.GetComponent<Camera>();
        Vector3 WorldPos = new Vector3(0, 0, 0);
        float Size = 0;

        switch (TrigPos) {
            case TriggerPosition.LEFT:
                WorldPos = PlayerCam.ScreenToWorldPoint(new Vector3(0, PlayerCam.pixelHeight / 2, 4));
                Size = PlayerCam.ScreenToWorldPoint(new Vector3(0, 0, 4)).y - PlayerCam.ScreenToWorldPoint(new Vector3(0, PlayerCam.pixelHeight, 4)).y;
                this.gameObject.transform.localScale = new Vector3(TrigSize, Size * 1.5f, 1);
                break;
            case TriggerPosition.RIGHT:
                WorldPos = PlayerCam.ScreenToWorldPoint(new Vector3(PlayerCam.pixelWidth, PlayerCam.pixelHeight / 2, 4.1f));
                Size = PlayerCam.ScreenToWorldPoint(new Vector3(0, 0, 4)).y - PlayerCam.ScreenToWorldPoint(new Vector3(0, PlayerCam.pixelHeight, 4)).y;
                this.gameObject.transform.localScale = new Vector3(TrigSize, Size * 1.5f, 1);
                break;
            case TriggerPosition.BOTTOM:
                WorldPos = PlayerCam.ScreenToWorldPoint(new Vector3(PlayerCam.pixelWidth / 2, 0, 4.2f));
                Size = PlayerCam.ScreenToWorldPoint(new Vector3(0, 0, 4)).x - PlayerCam.ScreenToWorldPoint(new Vector3(PlayerCam.pixelWidth, 0, 4)).x;
                this.gameObject.transform.localScale = new Vector3(Size * 1.5f, TrigSize, 1);
                break;
            case TriggerPosition.TOP:
                WorldPos = PlayerCam.ScreenToWorldPoint(new Vector3(PlayerCam.pixelWidth / 2, PlayerCam.pixelHeight, 4.3f));
                Size = PlayerCam.ScreenToWorldPoint(new Vector3(0, 0, 4)).x - PlayerCam.ScreenToWorldPoint(new Vector3(PlayerCam.pixelWidth, 0, 4)).x;
                this.gameObject.transform.localScale = new Vector3(Size * 1.5f, TrigSize, 1);
                break;
        }
        this.gameObject.transform.position = WorldPos;
    }
    void Update() {

    }

    void OnMouseEnter() {
        switch (TrigPos) {
            case TriggerPosition.LEFT:
                TriggerState.LeftTriggered = true;
                break;
            case TriggerPosition.RIGHT:
                TriggerState.RightTriggered = true;
                break;
            case TriggerPosition.BOTTOM:
                TriggerState.BottomTriggered = true;
                break;
            case TriggerPosition.TOP:
                TriggerState.TopTriggered = true;
                break;
        }
    }
    void OnMouseExit() {
        switch (TrigPos) {
            case TriggerPosition.LEFT:
                TriggerState.LeftTriggered = false;
                break;
            case TriggerPosition.RIGHT:
                TriggerState.RightTriggered = false;
                break;
            case TriggerPosition.BOTTOM:
                TriggerState.BottomTriggered = false;
                break;
            case TriggerPosition.TOP:
                TriggerState.TopTriggered = false;
                break;
        }
    }
}
