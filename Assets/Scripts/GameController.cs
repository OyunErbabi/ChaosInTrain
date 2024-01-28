using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    private void Awake()
    {
        Instance = this;
    }

    public List<GameObject> Passenger;
    public List<GameObject> Seats;
    public List<GameObject> TakenSeats;
    public GameObject train;

    private void Start()
    {
        Seats = new List<GameObject>();

        foreach (Transform child in train.transform)
        {
            if (child.CompareTag("Seat"))
            {
                Seats.Add(child.gameObject);
            }
        }

        StartGame();
    }

    void StartGame()
    {
        StartCoroutine(StartGameCor());
    }

    IEnumerator StartGameCor()
    {
        yield return null;
        while (true)
        {
            LevelManager.Instance.GiveRandomItem();
            SoundManager.instance.PlaySound(2);
            TrainController.Instance.OpenDoors();
            yield return new WaitForSeconds(2.5f);
            for (int i = 0; i < 2; i++)
            {
                Instantiate(Passenger[Random.Range(0, Passenger.Count)]);
                yield return new WaitForSeconds(1);
            }
            yield return new WaitForSeconds(1.5f);
            TrainController.Instance.CloseDoors();
            yield return new WaitForSeconds(2f);
            TrainMover.Instance.RunTrainWithTime(10f);
            SoundManager.instance.PlaySound(3);
            yield return new WaitForSeconds(13f);
            foreach (var item in ToolbarController.Instance.SpawnedItems)
            {
                item.GetComponent<ToolItemManager>().ResetItemCount();
            }

        }
    }
}
