using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ActionButtonBuild : ActionButton {


    private bool buildMenu = false;
    [SerializeField]
    private GameObject panelToShow;

    private Build BuildToDo;

    void Start() {
        ClickModeMan = ClickModeManager.GetInstance();
        panelToShow = GameObject.Find("Canvas").transform.Find("SubPanel").gameObject;
            
    }

    public override void OnClick() {
        if (buildMenu)
        {
            panelToShow.SetActive(false);
        }
        else
        {
            //this.ClickModeMan.Do = ActionToDo.Do;
            panelToShow.SetActive(true);
            this.SetUpPanel();
        }
        buildMenu = !buildMenu;
    }

    public override void SetActionToDo(Actions.Action toDo) {
        this.BuildToDo = toDo as Build;
    }

    private void SetUpPanel()
    {

        foreach (Transform child in panelToShow.transform.Find("Scroll View/Viewport/Content"))
        {
            GameObject.Destroy(child.gameObject);
        }
        foreach (var build in BuildToDo.BuildableList)
        {
            GameObject btnGO = new GameObject();
            btnGO.transform.parent = panelToShow.transform.Find("Scroll View/Viewport/Content"); 
            Button btn = btnGO.AddComponent<Button>();
            btnGO.AddComponent<Image>();
            if (build.BuildIcon != null) {
                btnGO.GetComponent<Image>().sprite = build.BuildIcon;
            }
            btn.onClick.AddListener(build.OnSelect);
            btn.onClick.AddListener(() =>
            {
             panelToShow.SetActive(false);   
            });
            
            
        }
    }
}
