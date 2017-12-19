using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.enabled = false;	
	}
	public void StartGame()
    {
        SceneManager.LoadScene("developScene");
    }
	public void ExitGame()
    {
        Application.Quit();
    }
}
