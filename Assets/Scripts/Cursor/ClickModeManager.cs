using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickModeManager : MonoBehaviour {

    public enum SelectMode { SELECT_ACTOR, SELECT_TARGET};

    [SerializeField]
    private SelectMode Mode = SelectMode.SELECT_ACTOR;
    [SerializeField]
    private GameObject ParentContent;
    [SerializeField]
    private Button ButtonToInstantiate;

    private IF_Selectable SelectedActor = null;
    private IF_Selectable SelectedTarget = null;
    private delegate void SelectedActionDo(object actor, object target);
    private SelectedActionDo Do;

	// Use this for initialization
	void Start () {
        this.enabled = false;
	}

    public void SetUpActions() {

    }

    public void ClickedOnGO(IF_Selectable GO) {
        switch (Mode) {
            case SelectMode.SELECT_ACTOR:
                SelectedActor = GO;
                SetupActionList();
                break;
            case SelectMode.SELECT_TARGET:
                this.SelectedTarget = GO;
                Do(SelectedActor, SelectedTarget);
                Mode = SelectMode.SELECT_ACTOR;
                break;
        }
    }
    
    public void SetDelegate() {

    }

    private void SetupActionList() {
        List<Action> actionList = SelectedActor.GetActionList();

        foreach (Transform child in ParentContent.transform) {
            GameObject.Destroy(child.gameObject);
        }

        foreach (Action act in actionList) {
            Button btn = Instantiate(ButtonToInstantiate);
            btn.GetComponentInChildren<Text>().text = act.name;
            btn.transform.parent = ParentContent.transform;
        }
        
    }
}
