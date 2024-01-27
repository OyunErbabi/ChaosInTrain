using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ArrowAnimator : MonoBehaviour
{
    public static ArrowAnimator Instance;

    GameObject CurrentSeat;

    private void Awake()
    {
        Instance = this;
    }

    Vector3 startPos;
    Vector3 UpPos;

    float SeatPosDiff = 0.44f;
    bool RunAnimation;

    private Vector3 initialPosition;
    public float moveSpeed = 5f;
    private float moveDirection = 0.5f;
    public float moveDistance = 0.25f;

    private void Update()
    {
        MoveUpDown();

        if(CurrentSeat != null)
        {
            if(CurrentSeat.GetComponent<SeatController>().status == SeatStatus.Taken || CurrentSeat.GetComponent<SeatController>().status == SeatStatus.TakenWithGlue)
            {
                ToggleArrow(false);
            }
            else
            {
                ToggleArrow(true);
            }
        }
    }
    private void MoveUpDown()
    {
        float newYPosition = initialPosition.y + moveDirection * moveDistance * Mathf.Sin(Time.time * moveSpeed);

        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
    }

    public void MoveArrowPosition(GameObject pos)
    {
        CurrentSeat = pos;
        RunAnimation = false;
        transform.position = new Vector3(pos.transform.position.x+SeatPosDiff, 1, 0);
        StartAnimation();
    }


    private void Start()
    {
        initialPosition = transform.position;
        StartAnimation();
    }

    void StartAnimation()
    {
        //RunAnimation = false;
        //startPos = transform.position;
        //UpPos = startPos + new Vector3(0, 1, 0);
        //StartCoroutine(AnimationCor());
    }

    private void OnEnable()
    {
        StartAnimation();
    }

    public void ToggleArrow(bool status)
    {
        GetComponent<SpriteRenderer>().enabled = status;
    }

    
}
