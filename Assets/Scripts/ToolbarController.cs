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
        if (ToolItem == null || BottomPanel == null)
        {
            Debug.LogError("ToolItem or BottomPanel is not assigned!");
            return;
        }

        for (int i = 0; i < Items.Count; i++)
        {
            // Ensure the current item and its sprite are not null
            if (Items[i] == null)
            {
                Debug.LogError("Item at index " + i + " is null!");
                continue;
            }

            if (Items[i].sprite == null)
            {
                Debug.LogError("Sprite is null for item: " + Items[i].name);
                continue;
            }

            GameObject gameObject = Instantiate(ToolItem, BottomPanel.transform);
            gameObject.name = Items[i].name;

            gameObject.GetComponent<Image>().sprite = Items[i].sprite;
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
