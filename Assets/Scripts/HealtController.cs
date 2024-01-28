using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtController : MonoBehaviour
{
    public static HealtController Instance;
    private void Awake()
    {
        Instance = this;
    }

    public List<GameObject> hearts;

    int CurrentHeart = 3;

    public void Fail()
    {
        CurrentHeart = CurrentHeart - 1;

        if(CurrentHeart <= 0)
        {
            //gameover
        }

        hearts[CurrentHeart].SetActive(false);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Fail();
        }
    }
}
