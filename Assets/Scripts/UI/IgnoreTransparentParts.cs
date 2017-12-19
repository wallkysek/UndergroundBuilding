using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class IgnoreTransparentParts : MonoBehaviour {

	
	void Awake () {
        gameObject.GetComponent<Image>().alphaHitTestMinimumThreshold = 1f;
    }
	
}
