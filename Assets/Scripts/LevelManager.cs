using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        //StartCoroutine(LateGiveItemCor());
    }

    IEnumerator LateGiveItemCor()
    {
        yield return null;
        GiveRandomItem();
    }

    public void GiveRandomItem()
    {
        for (int i = 0; i < 2; i++)
        {
            int randomItem = Random.Range(0, 2);
            
            //Debug.Log("Random İtem :" + randomItem);

            switch (randomItem)
            {
                case 0:
                    ToolbarController.Instance.BananaItem.GetComponent<ToolItemManager>().itemCount += 1;
                    ToolbarController.Instance.BananaItem.GetComponent<ToolItemManager>().CheckStatus();
                    break;
                case 1:
                    ToolbarController.Instance.GlueItem.GetComponent<ToolItemManager>().itemCount += 1;
                    ToolbarController.Instance.GlueItem.GetComponent<ToolItemManager>().CheckStatus();
                    break;
                case 2:
                    ToolbarController.Instance.BalloonItem.GetComponent<ToolItemManager>().itemCount += 1;
                    ToolbarController.Instance.BalloonItem.GetComponent<ToolItemManager>().CheckStatus();
                    break;

            }

        }
    }
    
}
