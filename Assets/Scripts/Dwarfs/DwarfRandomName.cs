using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfRandomName : MonoBehaviour
{
    [SerializeField]
    private List<string> firstName = new List<string>();
    [SerializeField]
    private List<string> secondName = new List<string>();

    public string getRandomName()
    {
        System.Random rand = new System.Random();
        int krand = rand.Next(0, firstName.Count);

        rand = new System.Random();
        int prand = rand.Next(0, secondName.Count);

        return (firstName[krand] + " " + secondName[prand]);
    }

    // Use this for initialization
    void Start ()
    {
        this.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
