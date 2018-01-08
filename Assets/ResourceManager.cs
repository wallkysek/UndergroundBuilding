using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    [SerializeField] private int stone;
    [SerializeField] private Text StoneDisplay;
    [SerializeField] private int crystal;

    public int Stone
    {
        get { return stone; }
        set { stone = value; }
    }

    public int Crystal
    {
        get { return crystal; }
        set { crystal = value; }
    }

    [SerializeField] private Text CrystalDisplay;
    private static ResourceManager me;

    private void Awake()
    {
        me = this;
    }

    public static ResourceManager GetInstance()
    {
        return me;
    }

    public void AddCrystal(int value)
    {
        crystal += value;
    }
    public void UseCrystal(int value)
    {
        if (crystal - value < 0)
        {
            throw new ResourceException("Need " + (value - crystal).ToString() + " more crystal.");
        }
        else
        {
            crystal -= value;
        }
    }
    public void AddStone(int value)
    {
        stone += value;
    }
    public void UseStone(int value)
    {
        if (stone - value < 0)
        {
            throw new ResourceException("Need " + (value - stone).ToString() + " more stone.");
        }
        else
        {
            stone -= value;
        }
    }

    private void Update()
    {
        StoneDisplay.text = stone.ToString();
        CrystalDisplay.text = crystal.ToString();
    }
}
