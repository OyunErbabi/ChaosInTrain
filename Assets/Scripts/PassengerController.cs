using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerController : MonoBehaviour
{

    CharacterController characterController;
    public Transform targetPosition;
    public float movementSpeed = 5f;
    public GameObject Smoke;

    public Animator animator;
    bool sitting;
    
    private void Start()
    {
        StartCoroutine(LateStart());
    }

    [System.Obsolete]
    IEnumerator LateStart()
    {
        yield return null;

        GameObject target = FindEmptySeat();
        if (target != null)
        {
            targetPosition = target.transform;
        }

        if(animator == null)
        {
            animator = GetComponent<Animator>();
        }

        characterController = GetComponent<CharacterController>();
        Instantiate(Smoke, transform.position, Quaternion.identity);
    }

    void Update()
    {
        if(targetPosition != null && !sitting)
        {
            MoveTowardsTarget();
            SetPassengerFaceDirection();
        }
    }

    [System.Obsolete]
    GameObject FindEmptySeat()
    {
        List<GameObject> EmptySeats = new List<GameObject>();
        EmptySeats.Clear();
        GameObject output = null;

        foreach (var item in GameController.Instance.Seats)
        {
            if (item.GetComponent<SeatController>().status == SeatStatus.Empty || item.GetComponent<SeatController>().status == SeatStatus.Glued)
            {
                EmptySeats.Add(item);
            }
        }

        if (EmptySeats.Count > 0)
        {
            output = EmptySeats[Random.RandomRange(0, EmptySeats.Count - 1)];
        }
        
        return output;
    }

    void MoveTowardsTarget()
    {
        if (characterController == null || targetPosition == null)
        {
            return;
        }

        Vector3 direction = targetPosition.position - transform.position;
        direction.y = 0f;

        if (direction.magnitude > 0.1f)
        {
            characterController.Move(direction.normalized * movementSpeed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position,targetPosition.position)< 0.1f)
        {
            sitting = true;
            animator.SetBool("Walk", false);
            targetPosition.gameObject.GetComponent<SeatController>().SitOnSeat();
            animator.SetTrigger("Sit");
        }
        else
        {
            if (Mathf.Abs(direction.x) > 0.1f)
            {
                animator.SetBool("Walk", true);
            }
            else
            {
                sitting = true;
                animator.SetBool("Walk", false);
                targetPosition.gameObject.GetComponent<SeatController>().SitOnSeat();
                animator.SetTrigger("Sit");
            }
        }

       
    }

    void SetPassengerFaceDirection()
    {
        Vector3 direction = targetPosition.position - transform.position;
        direction.y = 0f;

        if (direction.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }

        //if(GetComponent<SpriteRenderer>() == null)
        //{
        //    if (direction.x > 0)
        //    {
        //        GetComponent<SpriteRenderer>().flipX = false;
        //    }
        //    else if (direction.x < 0)
        //    {
        //        GetComponent<SpriteRenderer>().flipX = true;
        //    }
        //}
        //else
        //{
        //    if (direction.x > 0)
        //    {
        //        transform.rotation = Quaternion.Euler(0, -180, 0);
        //    }
        //    else if (direction.x < 0)
        //    {
        //        transform.rotation = Quaternion.Euler(0, 0, 0);
        //    }
        //}

    }
}
