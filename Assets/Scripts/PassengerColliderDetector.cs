using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerColliderDetector : MonoBehaviour
{
    public PassengerController controller;

    bool felt;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "banana")
        {
            if (!felt)
            {
                felt = true;
                controller.Fall(collision.gameObject);
            }
        }

    }

   


}
