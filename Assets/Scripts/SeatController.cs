using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SeatController : MonoBehaviour
{
    public Sprite SeatEmpty;
    public Sprite SeatWithGlue;

    SpriteRenderer renderer;
    bool isGlued;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeToGlue()
    {
        renderer.sprite = SeatWithGlue;
    }

    public void ChangeToEmpty()
    {
        renderer.sprite = SeatEmpty;
    }

    public void ToggleSeatStatus()
    {
        if (isGlued)
        {
            ChangeToEmpty();
        }
        else
        {
            ChangeToGlue();
        }

        isGlued = !isGlued;
    }
}
