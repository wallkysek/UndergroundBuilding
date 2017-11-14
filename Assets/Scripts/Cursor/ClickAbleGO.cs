using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAbleGO : MonoBehaviour {

    [SerializeField]
    private ClickModeManager ClickManager;
    [SerializeField]
    private IF_Selectable Me; 
    
    

    void Start() {
        Me = this.gameObject.GetComponent<IF_Selectable>();
        if (Me == null) {
            Debug.Log("Missing Selectable script");
            //TODO: Exception
        }
    }

    private void OnMouseUpAsButton() {
        ClickManager.ClickedOnGO(Me);
    }
}
