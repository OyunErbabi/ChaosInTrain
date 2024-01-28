using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    //private int currentLevel = 0;
    //public Text levelText;
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

    //public void IncrementLevel()
    //{
    //    currentLevel++;
    //    UpdateLevelText();
    //}

    //void UpdateLevelText()
    //{
    //    if (levelText != null)
    //    {
    //        levelText.text = "Level: " + currentLevel.ToString();
    //    }
    //}

}
