using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndestroyableGO : MonoBehaviour
{
	private static GameObject instance;

	void Awake()
	{
		if (instance != null && instance != this.gameObject)
		{
			Destroy(this.gameObject);
		}
		else
		{
			instance = this.gameObject;
		}
		DontDestroyOnLoad(this.gameObject);
	}
}
