using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using DG.Tweening;
using Vector3 = UnityEngine.Vector3;


public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    public List<GameObject> Seats;

    GameObject train;

    GameObject nearestSeat;

    public Animator animator;

    public float MinX;
    public float MaxX;

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
        if(transform.position.x < MaxX  && transform.position.x > MinX)
        {
            Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

            if (Mathf.Abs(move.x) > 0)
            {
                animator.SetBool("Walk", true);
            }
            else
            {
                animator.SetBool("Walk", false);
            }

            FlipCharacter();
            controller.Move(move * Time.deltaTime * 10);

            if (Input.GetKeyDown(KeyCode.E))
            {
                FindNearestSeat();
                if (nearestSeat != null)
                {
                    nearestSeat.GetComponent<SeatController>().ToggleSeatStatus();
                }
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                BananaController.Instance.PlaceBananaAtPlayerFeet();
            }
        }
        else
        {
            transform.DOMove ( new Vector3(Mathf.Clamp(transform.position.x, MinX+0.001f, MaxX-0.001f),transform.position.y,transform.position.z),0.1f);
            animator.SetBool("Walk", false);
        }

    }

    void FlipCharacter()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
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
