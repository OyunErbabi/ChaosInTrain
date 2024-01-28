using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public string GameOverScene;
    public TMP_Text LevelText;
    public int levelCount = 0;

    private void Awake()
    {
        Instance = this;
    }

    public List<GameObject> Passenger;
    public List<GameObject> Seats;
    public List<GameObject> TakenSeats;
    public GameObject train;
    public bool isOver;

    public GameObject GameOverCircle;

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

    private void Update()
    {
        //if (isOver)
        //{
        //    // Start the coroutine to introduce a delay before changing the scene
            
            
        //}
    }

    public void GameOverCallBack()
    {
        StartCoroutine(DelayedSceneChange());
    }

    IEnumerator DelayedSceneChange()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);
        PlayerPrefs.SetInt("Level", levelCount);
        GameOverCircle.transform.localScale = Vector3.zero;
        GameOverCircle.SetActive(true);
        GameOverCircle.transform.DOScale(Vector3.one * 30, 1);
        yield return new WaitForSeconds(1f);
        // Change the scene after the delay
        SceneManager.LoadScene(GameOverScene);
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
            levelCount++;
            LevelText.text = "Level " + levelCount;
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
