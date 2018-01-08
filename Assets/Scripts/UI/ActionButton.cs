using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ActionButton : Button {


    protected ClickModeManager ClickModeMan;

    private Actions.Action ActionToDo;

    void Start() {
        ClickModeMan = ClickModeManager.GetInstance();
    }

    public virtual void OnClick() {
        this.ClickModeMan.Do = ActionToDo.Do;
        this.ClickModeMan.Mode = ClickModeManager.SelectMode.SELECT_TARGET;
    }

    public virtual void SetActionToDo(Actions.Action toDo) {
        this.ActionToDo = toDo;
    }
}
