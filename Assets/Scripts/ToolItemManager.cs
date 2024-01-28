using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UiItemType { glue, banana ,balloon}

public class ToolItemManager : MonoBehaviour
{
    public Text itemCountText;
    public int itemCount;

    public GameObject itemTextObject;
    public Button button;
    public UiItemType type;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Press);
        ToggleButton(false);
    }

    void ToggleButton(bool status)
    {
        button.interactable = status;
        if(button.interactable)
        {
            itemCountText.text = "" + itemCount;
            itemTextObject.SetActive(true);
        }
        else
        {
            itemTextObject.SetActive(false);
        }
    }

    public void CheckStatus()
    {
        if (itemCount > 0)
        {
            ToggleButton(true);
        }
        else if(itemCount <= 0)
        {
            ToggleButton(false);
        }
    }

    void Press()
    {
        switch (type)
        {
            case UiItemType.banana:
                BananaController.Instance.PlaceBananaAtPlayerFeet();
                itemCount = itemCount - 1;
                CheckStatus();
                break;
            case UiItemType.glue:
                if (PlayerController.Instance.UseGlue())
                {
                    itemCount = itemCount - 1;
                }
                CheckStatus();
                break;
            case UiItemType.balloon:
                break;
        }

        Debug.Log("Pressed "+type);
    }

    public void ResetItemCount()
    {
        itemCount = 0;
        CheckStatus();
    }


}
