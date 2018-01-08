using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource_Crystal : Resource
{
    private int value;
    [SerializeField] private int genMin = 5;
    [SerializeField] private int genMax = 15;

    override public void Harvest()
    {
        GameObject resourceManagerGO = GameObject.Find("ResourceManager");
        if (resourceManagerGO != null)
        {
            ResourceManager resMananger = resourceManagerGO.GetComponent<ResourceManager>();
            resMananger.AddCrystal(value);
            Destroy(this.gameObject);
        }
        
    }

    private void Start()
    {
        value = Random.Range(genMin, genMax);
    }
}