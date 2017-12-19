using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAbleGO : MonoBehaviour {

    private ClickModeManager ClickManager;
    private IF_Selectable Me;



    void Start() {
        Me = this.gameObject.GetComponent<IF_Selectable>();
        if (Me == null) {
            Debug.Log("Missing Selectable script");
            //TODO: Exception
        }
        this.ClickManager = GameObject.Find("ClickModeManager").GetComponent<ClickModeManager>();
    }

    private void OnMouseDown() { 
        //ClickManager.ClickedOnGO(Me.GetTarget());
    }
}
