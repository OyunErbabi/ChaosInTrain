using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SeatStatus { Empty, Glued, Taken, TakenWithGlue }

public class SeatController : MonoBehaviour
{
    public Sprite SeatEmpty;
    public Sprite SeatWithGlue;

    SpriteRenderer renderer;
    bool isGlued;

    public SeatStatus status;

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
            status = SeatStatus.Glued;
        }

        isGlued = !isGlued;
    }

    public void SitOnSeat()
    {
        Debug.Log("On Sit");
        switch (status)
        {
            case SeatStatus.Empty:
                status = SeatStatus.Taken;
                GameController.Instance.TakenSeats.Add(gameObject);
                break;
            case SeatStatus.Glued:
                status = SeatStatus.TakenWithGlue;
                GameController.Instance.TakenSeats.Add(gameObject);
                break;
            case SeatStatus.Taken:
                //status = SeatStatus.Empty;
                break;
            case SeatStatus.TakenWithGlue:
                status = SeatStatus.Glued;
                break;
        }
    }
}
