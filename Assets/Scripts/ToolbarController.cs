using System;

using System.Collections.Generic;
using UnityEngine;

public class ToolbarController : MonoBehaviour
{
    public static ToolbarController Instance;

    [SerializeField]
    public List<Item> Items;


    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
}

[Serializable]
public class Item
{
    public string name;
    public Sprite sprite;
}