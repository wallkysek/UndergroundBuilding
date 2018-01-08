using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ActionMenuButton : Button {

    private ClickModeManager ClickModeMan;

    private List<Actions.Action> ActionsToShow;

    void Start() {
        ClickModeMan = ClickModeManager.GetInstance();
    }

    public void OnClick() {
        this.ClickModeMan.SetupActionMenu(this.ActionsToShow);
    }

    public void SetActionsToShow(List<Actions.Action> Actions) {
        this.ActionsToShow = Actions;
    }
}
