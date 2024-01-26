using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;


public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    public List<GameObject> Seats;

    GameObject train;

    GameObject nearestSeat;
    private void Start()
    {
        train = GameObject.Find("Train");

        Seats = new List<GameObject>();

        foreach (Transform child in train.transform)
        {
            if (child.CompareTag("Seat"))
            {
                Seats.Add(child.gameObject);
            }
        }
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * 10);

        if (Input.GetKeyDown(KeyCode.E))
        {
            FindNearestSeat();
            if (nearestSeat != null)
            {
                nearestSeat.GetComponent<SeatController>().ChangeToGlue();
            }
        }

    }


    void FindNearestSeat()
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in Seats)
        {
            float diff = Vector3.Distance(go.transform.position, position);
            if (diff < distance)
            {
                distance = diff;
                nearestSeat = go;
            }
        }
    }


}
