using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickModeManager : MonoBehaviour {

    public enum SelectMode { SELECT_ACTOR, SELECT_TARGET};

    
    public SelectMode Mode = SelectMode.SELECT_ACTOR;
    [SerializeField]
    private GameObject ParentContent;
    [SerializeField]
    private Button ButtonToInstantiate;

    private IF_Actor SelectedActor = null;
    private IF_Target SelectedTarget = null;

    public delegate void SelectedActionDo(object actor, object target);
    public SelectedActionDo Do;

    private static ClickModeManager Me;

	// Use this for initialization
	void Start () {
        this.enabled = false;
        Me = this;
	}

    public static ClickModeManager GetInstance() {
        return Me;
    }

    public void SetUpActions() {

    }

    public void ClickedOnGO(GameObject GO) {
        switch (Mode) {
            case SelectMode.SELECT_ACTOR:
                SelectedActor = GO.GetComponent<IF_Actor>();
                if (this.SelectedActor == null) {
                    Debug.Log("Not a valid actor");
                    return;
                }
                SetupActionList();
                break;
            case SelectMode.SELECT_TARGET:
                this.SelectedTarget = GO.GetComponent<IF_Target>();
                if (this.SelectedTarget == null) {
                    Debug.Log("Not a valid target");
                    return;
                }
                if (this.SelectedActor == null) {
                    Debug.Log("Not a valid actor");
                    Mode = SelectMode.SELECT_ACTOR;
                    return;
                }
                Do(SelectedActor, SelectedTarget);
                Mode = SelectMode.SELECT_ACTOR;
                break;
        }
    }
    

    private void SetupActionList() {
        List<Action> actionList = SelectedActor.GetActions();

        foreach (Transform child in ParentContent.transform) {
            GameObject.Destroy(child.gameObject);
        }

        foreach (Action act in actionList) {
            act.GetButton().transform.SetParent(ParentContent.transform);
        }
        
    }
}
