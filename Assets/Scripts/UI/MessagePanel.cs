using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagePanel : MonoBehaviour {

    private Text messageText;
    public float showDelayTime;
    private bool showing = false;
    private float showStartTime;
    private static MessagePanel me;

	void Start () {
        messageText = gameObject.GetComponent<Text>();
        gameObject.SetActive(false);
	    me = this;
	}
	
	public void DisplayMessage(string message) {
        messageText.text = message;
        showing = true;
        gameObject.SetActive(true);
        showStartTime = Time.time;
    }

    private void Update() {
        if ((showing==true)&&(Time.time>showStartTime+showDelayTime)) {
            showing = false;
            gameObject.SetActive(false);
        }
    }

    public static MessagePanel getInstance()
    {
        return me;
    }
}
