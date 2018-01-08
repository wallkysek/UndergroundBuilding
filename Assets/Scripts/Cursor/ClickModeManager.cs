using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickModeManager : MonoBehaviour {

    public enum SelectMode { SELECT_ACTOR, SELECT_TARGET, SELECT_NOT};

    
    public SelectMode Mode = SelectMode.SELECT_ACTOR;
    [SerializeField]
    private GameObject ParentContent;
    [SerializeField]
    private GameObject MenuParentContent;
    [SerializeField]
    private Button ButtonToInstantiate;
    [SerializeField]
    private GameObject MenuParentBackground;
    [SerializeField]
    private DwarfPanel dwarfPanel;

    [SerializeField] private MessagePanel msgPanel;

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
            
        Debug.Log(GO.name);
        switch (Mode) {
            case SelectMode.SELECT_ACTOR:
                SelectedActor = GO.GetComponent<IF_Actor>();
                if (this.SelectedActor == null) {
                    dwarfPanel.HidePanel();
                    this.ClearActionBars();
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
                    dwarfPanel.HidePanel();
                    this.ClearActionBars();
                    Debug.Log("Not a valid actor");
                    Mode = SelectMode.SELECT_ACTOR;
                    return;
                }
                try
                {
                    Do(SelectedActor, SelectedTarget);
                }
                catch (ActionException Aex)
                {
                    msgPanel.DisplayMessage(Aex.Message);
                }
                Mode = SelectMode.SELECT_ACTOR;
                break;
        }
    }
    

    private void SetupActionList() {
        List<Actions.Action> actionList = SelectedActor.GetActions();
        foreach (Transform child in ParentContent.transform) {
            GameObject.Destroy(child.gameObject);
        }

        foreach (Actions.Action act in actionList) {
            act.GetButton().transform.SetParent(ParentContent.transform);
        }
    }

    public void SetupActionMenu(List<Actions.Action> Actions) {
        if (MenuParentBackground.activeSelf == false) {
            MenuParentBackground.SetActive(true);
            foreach (Transform child in MenuParentContent.transform) {
                GameObject.Destroy(child.gameObject);
            }

            foreach (Actions.Action act in Actions) {
                act.GetButton().transform.SetParent(MenuParentContent.transform);
            }
        }
        else {
            MenuParentBackground.SetActive(false);
        }
    }

    private void ClearActionBars() {
        MenuParentBackground.SetActive(false);
        foreach (Transform child in MenuParentContent.transform) {
            GameObject.Destroy(child.gameObject);
        }
        foreach (Transform child in ParentContent.transform) {
            GameObject.Destroy(child.gameObject);
        }
    }
}
