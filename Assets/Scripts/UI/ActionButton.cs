using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ActionButton : Button {


    private ClickModeManager ClickModeMan;

    private Action ActionToDo;

    void Start() {
        ClickModeMan = ClickModeManager.GetInstance();
    }

    public void OnClick() {
        this.ClickModeMan.Do = ActionToDo.Do;
        this.ClickModeMan.Mode = ClickModeManager.SelectMode.SELECT_TARGET;
    }

    public void SetActionToDo(Action toDo) {
        this.ActionToDo = toDo;
    }
}
