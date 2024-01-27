using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PessengerController : MonoBehaviour
{

    CharacterController characterController;
    public Transform targetPosition;
    public float movementSpeed = 5f;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        characterController.isTrigger = true;
    }

    void Update()
    {
        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        if (characterController == null || targetPosition == null)
        {
            Debug.LogError("CharacterController veya hedef pozisyon atanmamış.");
            return;
        }

        Vector3 direction = targetPosition.position - transform.position;
        direction.y = 0f; 

        if (direction.magnitude > 0.1f)
        {
            characterController.Move(direction.normalized * movementSpeed * Time.deltaTime);
        }
    }
}
