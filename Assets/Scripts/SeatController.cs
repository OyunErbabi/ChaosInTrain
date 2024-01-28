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
    public bool SeatInUse;
    bool playerSitOnGlue = false;
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
            SoundManager.instance.PlaySound(6);
        }

        isGlued = !isGlued;
    }

    public void GetUpAndClearSeat(bool state)
    {
        Debug.Log("GetUP");
        if (state)
        {
            status = SeatStatus.Empty;
        }

        //if (playerSitOnGlue)
        //{
        //    status = SeatStatus.Empty;
        //}
        //else if(status == SeatStatus.Glued && !playerSitOnGlue) 
        //{
        //    status = SeatStatus.Glued;
        //}
        //else
        //{
        //    status = SeatStatus.Empty;
        //}

        
        GameController.Instance.TakenSeats.Remove(gameObject);
        SeatInUse = false;
    }

    public void SitOnSeat(GameObject passengerObject)
    {
        Debug.Log("On Sit");
        if (!SeatInUse)
        {
            return;
        }

        switch (status)
        {
            case SeatStatus.Empty:
                status = SeatStatus.Taken;
                GameController.Instance.TakenSeats.Add(gameObject);
                break;
            case SeatStatus.Glued:
                status = SeatStatus.TakenWithGlue;
                playerSitOnGlue = true;
                GameController.Instance.TakenSeats.Add(gameObject);
                passengerObject.GetComponent<PassengerController>().SitGlue(this.gameObject);
                break;
            case SeatStatus.Taken:
                //status = SeatStatus.Empty;
                break;
            case SeatStatus.TakenWithGlue:
                status = SeatStatus.Glued;
                break;
        }
    }

    public void SeatSelected()
    {
        SeatInUse = true;


        //switch (status)
        //{
        //    case SeatStatus.Empty:
        //        status = SeatStatus.Taken;
        //        GameController.Instance.TakenSeats.Add(gameObject);
        //        break;
        //    case SeatStatus.Glued:
        //        status = SeatStatus.TakenWithGlue;
        //        GameController.Instance.TakenSeats.Add(gameObject);
        //        break;
        //    case SeatStatus.Taken:
        //        //status = SeatStatus.Empty;
        //        break;
        //    case SeatStatus.TakenWithGlue:
        //        status = SeatStatus.Glued;
        //        break;
        //}
    }
}
