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

    private void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        Instantiate(Smoke, transform.position, Quaternion.identity);
    }

    void Update()
    {
        if(targetPosition != null)
        {
            MoveTowardsTarget();
            SetPassengerFaceDirection();
        }
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
            animator.SetBool("Walk", false);
        }
        else
        {
            if (Mathf.Abs(direction.x) > 0.1f)
            {
                animator.SetBool("Walk", true);
            }
            else
            {
                animator.SetBool("Walk", false);
            }
        }

       
    }

    void SetPassengerFaceDirection()
    {
        Vector3 direction = targetPosition.position - transform.position;
        direction.y = 0f;
        if (direction.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (direction.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
