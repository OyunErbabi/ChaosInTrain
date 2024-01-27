using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        StartCoroutine(StartGameCor());
    }

    IEnumerator StartGameCor()
    {
        while (true)
        {
            TrainController.Instance.OpenDoors();
            yield return new WaitForSeconds(5f);
            TrainController.Instance.CloseDoors();
            yield return new WaitForSeconds(2f);
            TrainMover.Instance.RunTrainWithTime(10f);
            yield return new WaitForSeconds(13f);
        }
    }
}
