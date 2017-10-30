using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    [SerializeField]
    private int mX1;
    [SerializeField]
    int mY1;
    [SerializeField]
    int mX2;
    [SerializeField]
    int mY2;

    void Awake() {
        this.enabled = false;    
    }
}
