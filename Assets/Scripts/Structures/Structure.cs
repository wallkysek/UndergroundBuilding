using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Structure : MonoBehaviour {

    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private string structureName;
    private GameObject model;

    private void Start() {
        model = this.gameObject;
    }

    public string GetName() {
        return structureName;
    }

    public Sprite GetIcon() {
        return icon;
    }

    public GameObject GetModel() {
        return model;
    }
}
