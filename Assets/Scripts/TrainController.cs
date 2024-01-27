using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrainController : MonoBehaviour
{
    public static TrainController Instance;

    private void Awake()
    {
        Instance = this;
    }

    public GameObject LeftDoor;
    public GameObject RightDoor;

    public Vector3 LeftDoorOpenPos;
    public Vector3 LeftDoorClosedPos;

    public Vector3 RightDoorOpenPos;
    public Vector3 RightDoorClosedPos;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            OpenDoors();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            CloseDoors();
        }
    }

    public void OpenDoors()
    {
        LeftDoor.transform.DOLocalMove(LeftDoorOpenPos, 1f);
        RightDoor.transform.DOLocalMove(RightDoorOpenPos, 1f);

    }
    

    public void CloseDoors()
    {
        LeftDoor.transform.DOLocalMove(LeftDoorClosedPos, 1f);
        RightDoor.transform.DOLocalMove(RightDoorClosedPos, 1f);
    }
}
