using System;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class ToolbarController : MonoBehaviour
{
    public static ToolbarController Instance;

    [SerializeField]
    public List<Item> Items;

    public GameObject ToolItem;
    public GameObject BottomPanel;


    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        for (int i = 0; i < Items.Count;i++)
        {
            GameObject gameObject = Instantiate(ToolItem,BottomPanel.transform);
            gameObject.name = Items[i].name;
            //gameObject.AddComponent<Image>().sprite = Items[i].sprite;
            //gameObject.transform.parent = BottomPanel.transform;

        }
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