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
    public bool sitting;

    public GameObject ColliderDetector;
    GameObject SpawnedDetector;

    public float DetectorHeight;
    GameObject trigerredObject;
    GameObject SeatTrigger;
    GameObject target;

    bool SeatSelected;
    private void Start()
    {
        SoundManager.instance.PlaySound(0);
        SpawnedDetector = Instantiate(ColliderDetector, transform.position, Quaternion.identity);
        SpawnedDetector.GetComponent<PassengerColliderDetector>().controller = this;
        StartCoroutine(LateStart());
    }

    [System.Obsolete]
    IEnumerator LateStart()
    {
        yield return null;

        target = FindEmptySeat();
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

        

        if(SpawnedDetector != null)
        {
            SpawnedDetector.transform.position = new Vector3(transform.position.x, transform.position.y + DetectorHeight, transform.position.z);
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
                if (!item.GetComponent<SeatController>().SeatInUse)
                {
                    EmptySeats.Add(item);
                }
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

        if (!SeatSelected)
        {
            SeatSelected = true;
            //targetPosition.gameObject.GetComponent<SeatController>().SitOnSeat(this.gameObject);
            targetPosition.gameObject.GetComponent<SeatController>().SeatSelected();
        }
        //Burası Tekrar Çağırılmamalı



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
            targetPosition.gameObject.GetComponent<SeatController>().SitOnSeat(this.gameObject);
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
                targetPosition.gameObject.GetComponent<SeatController>().SitOnSeat(this.gameObject);
                animator.SetTrigger("Sit");
            }
        }


    }
    public void SitGlue(GameObject triggerObj)
    {
        SeatTrigger = triggerObj;
        SoundManager.instance.PlaySound(4);
        StartCoroutine(DelayedSoundPlay(7, 0.1f));
        StartCoroutine(DelayedSoundPlay(5, 2f));

        StartCoroutine(DeleteFromScene());
    }

    IEnumerator DelayedSoundPlay(int soundIndex, float delay)
    {
        yield return new WaitForSeconds(delay);

        SoundManager.instance.PlaySound(soundIndex);
    }

    public void Fall(GameObject trigerObject)
    {
        trigerredObject = trigerObject;
        trigerObject.GetComponent<BoxCollider2D>().enabled = false;
        targetPosition = null;
        animator.SetTrigger("Fall");
        SoundManager.instance.PlaySound(1);
        StartCoroutine(DeleteFromScene());
    }

    IEnumerator DeleteFromScene()
    {
        //yield return new WaitForSeconds(0.5f);
        
        yield return new WaitForSeconds(2);
        Instantiate(Smoke, transform.position, Quaternion.identity);

        if (trigerredObject != null)
        {
            Destroy(trigerredObject);
        }

        if (SeatTrigger!=null)
        {
            SeatTrigger.GetComponent<SeatController>().ToggleSeatStatus();
        }

        Destroy(SpawnedDetector);
        target.GetComponent<SeatController>().GetUpAndClearSeat(sitting);
        sitting = true;


        SoundManager.instance.PlaySound(8);
        Destroy(this.gameObject);
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
    }

   
}
