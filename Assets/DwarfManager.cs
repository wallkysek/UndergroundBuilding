using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DwarfManager : MonoBehaviour
{

	private int count = 0;
	
	// Update is called once per frame
	void Update ()
	{
		count = 0;
		foreach (GameObject GO in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
		{
			if (GO.tag == "Dwarf")
			{
				count++;
			}
		}
		if (count == 0)
		{
			SceneManager.LoadScene("gameOverScene");
		}
	}
}
