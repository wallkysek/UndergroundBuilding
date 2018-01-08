using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DwarfPanel : MonoBehaviour {

    [SerializeField]
    private GameObject energyBar;
    [SerializeField]
    private Text namePlate;
    private int dwarfId = -1;


    public void SetPanel(string name, float energy, int id) {
        this.gameObject.SetActive(true);
        namePlate.text = name;
        RefreshEnergyBar(energy);
        SetDwarfId(id);
    }

    public void RefreshEnergyBar(float energy) {
        energyBar.transform.localScale = new Vector3(1f, energy, 1f);
    }

    public void HidePanel() {
        this.gameObject.SetActive(false);
        dwarfId = -1;
    }

    private void Start() {
        dwarfId = -1;
        HidePanel();
    }

    private void SetDwarfId(int id) {
        dwarfId = id;
    }

    public int GetDwarfId() {
        return dwarfId;
    }
}
