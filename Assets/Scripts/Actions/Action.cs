﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Actions
{

    [Serializable]

    public abstract class Action : MonoBehaviour
    {
        public abstract void Do(object actor, object target);

        [SerializeField]
        protected string Name = "Action";
        [SerializeField]
        private ActionButton Button;
        [SerializeField]
        protected Sprite icon;

        protected GameObject Actor;
        protected GameObject Target;

        private void Select()
        {

        }

        /*public void Update() {
            Debug.Log("ewqewq");
        }*/


        public ActionButton GetButton()
        {
            ActionButton ActButton = Instantiate(Button);
            if (icon != null)
            {
                ActButton.GetComponent<Image>().sprite = icon;
                ActButton.GetComponentInChildren<Text>().text = "";
            }
            else
            {
                ActButton.GetComponentInChildren<Text>().text = this.Name;
            }
            ActButton.SetActionToDo(this);

            return ActButton;
        }
    }
}