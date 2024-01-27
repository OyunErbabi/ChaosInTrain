using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Security.Cryptography;

public class TrainMover : MonoBehaviour
{
    public static TrainMover Instance;
    private void Awake()
    {
        Instance = this;
    }

    public GameObject Pole;
    public GameObject Light;
    public GameObject Station;

    public bool RunTrain;
    public AnimationCurve curve;
    private void Start()
    {
        //RunTrain = true;
        //StartCoroutine(RunTrainCor());
    }

    float timer;
    public float RunTime;
    private void Update()
    {
        if (RunTrain)
        {
            timer = timer + Time.deltaTime;
            if (timer > RunTime)
            {
                timer = 0;
                RunTrain = false;
            }
        }
    }

    public void RunTrainWithTime(float time)
    {
        RunTime = time;
        RunTrain = true;
        StartCoroutine(RunTrainCor());
    }

    IEnumerator RunTrainCor()
    {
        StartCoroutine(MoveOverTime(-20, 2f));
        yield return new WaitForSeconds(2);
        while (RunTrain)
        {
            GameObject _TempObject = Instantiate(Light,new Vector3(20, 2.33f, 0),Quaternion.identity);
            _TempObject.transform.DOMoveX(-20, 1);
            yield return new WaitForSeconds(1f);
            Destroy(_TempObject);
        }
        StartCoroutine(MoveOverTime(0, 2f));

    }

    IEnumerator MoveOverTime(float targetPosition, float duration)
    {
        float elapsedTime = 0f;
        Vector3 initialPosition = Station.transform.position;

        while (elapsedTime < duration)
        {
            float normalizedTime = elapsedTime / duration;
            float curveValue = curve.Evaluate(normalizedTime);

            Station.transform.position = new Vector3(initialPosition.x + curveValue * (targetPosition - initialPosition.x), initialPosition.y, initialPosition.z);
           
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Station.transform.position = new Vector3(-Station.transform.position.x, Station.transform.position.y, Station.transform.position.z);
    }

}
