using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using World.WorldUtils;

public class Dwarf : Unit, IF_CanDestroy, IF_Actor, IPointerDownHandler {

    private delegate void ActionHandler();
    private ActionHandler ActionsToDo;

    [SerializeField]
    private float ActionRange = 0.6f;
    [SerializeField]
    private float Speed = 0.01f;
    [SerializeField]
    private Vector3 MovingToPosition;


    public void Destroy(IF_Destroyable target) {
        ActionsToDo = target.Destroy;
        IF_Target tar = (IF_Target)target;
        MovingToPosition = tar.GetTargetPosition();
    }

    public void Update() {
        if (Vector3.Distance(this.transform.position, this.MovingToPosition) > ActionRange) {
            this.transform.position = Vector3.MoveTowards(this.transform.position,
                MovingToPosition, Speed * Time.deltaTime);
        } else {
            if (ActionsToDo != null) {
                ActionsToDo();
                ActionsToDo = null;
            }
        }
    }

    public List<Action> GetActions() {
        return this.Actions;
    }

    /*void OnMouseDown() {
        if (!EventSystem.current.IsPointerOverGameObject())
            ClickModeManager.GetInstance().ClickedOnGO(this.gameObject);
    }*/


    void Start() {
        this.MovingToPosition = this.gameObject.transform.position;
        this.enabled = true;
    }

    public void OnPointerDown(PointerEventData eventData) {
        ClickModeManager.GetInstance().ClickedOnGO(this.gameObject);
    }

    public void SetPosition(Vector3 pos) {
        MovingToPosition = pos;
    }
}
