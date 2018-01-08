using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Prebuild : MonoBehaviour, IPointerDownHandler
{
	[SerializeField] private GameObject toBuild;
	[SerializeField] private Sprite buildIcon;
	[SerializeField] private string buildName;
	[SerializeField] private int stoneUse;
	[SerializeField] private int crystalUse;
	[SerializeField] private Material ok;
	[SerializeField] private Material notOk;
	
	private bool instantiated = false;
	private MeshRenderer[] renderers;
	private bool placeable = false; 
	
	private void Start()
	{
		renderers = this.gameObject.GetComponentsInChildren<MeshRenderer>();
	}

	private void Update()
	{
		if (!Instantiated)
			return;
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 1 - Camera.current.gameObject.transform.position.z;
		Vector3 inGamePos = Camera.current.ScreenToWorldPoint(mousePos);
		inGamePos.x = Mathf.Round(inGamePos.x);
		inGamePos.y = Mathf.Round(inGamePos.y);
		
		transform.position = inGamePos;
		
	}


	public GameObject ToBuild
	{
		get { return toBuild; }
	}

	public Sprite BuildIcon
	{
		get { return buildIcon; }
	}

	public string BuildName
	{
		get { return buildName; }
	}

	public void OnSelect()
	{
		
		ResourceManager resMan = ResourceManager.GetInstance();
		int stoneStock = resMan.Stone;
		int crystalStock = resMan.Crystal;
		try
		{
			resMan.UseStone(stoneUse);
			resMan.UseCrystal(crystalUse);
			GameObject GO = Instantiate(this.gameObject);
			GO.GetComponent<Prebuild>().Instantiated = true;
			ClickModeManager.GetInstance().Mode = ClickModeManager.SelectMode.SELECT_NOT;
		}
		catch (ResourceException rex)
		{
			resMan.Stone = stoneStock;
			resMan.Crystal = crystalStock;
			MessagePanel.getInstance().DisplayMessage(rex.Message);
		}
	}

	public bool Instantiated
	{
		get { return instantiated; }
		set { instantiated = value; }
	}
	

	private void OnTriggerStay(Collider other)
	{
		if (!placeable)
			return;
		this.placeable = false;
		Debug.Log("Not placeable!");
		foreach (MeshRenderer rend in renderers)
		{
			var mats = new Material[rend.materials.Length];
			for (int i = 0; i < rend.materials.Length; i++)
			{
				mats[i] = notOk;
			}
			rend.materials = mats;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (placeable)
			return;
		this.placeable = true;
		Debug.Log("Placeable!");
		foreach (MeshRenderer rend in renderers)
		{
			var mats = new Material[rend.materials.Length];
			for (int i = 0; i < rend.materials.Length; i++)
			{
				mats[i] = ok;
			}
			rend.materials = mats;
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (placeable)
		{
			Instantiate(this.toBuild, this.gameObject.transform.position, Quaternion.identity);
		}
		ClickModeManager.GetInstance().Mode = ClickModeManager.SelectMode.SELECT_ACTOR;
		Destroy(this.gameObject);
		
	}
}
