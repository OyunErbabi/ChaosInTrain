using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MaınMenu : MonoBehaviour
{
    public GameObject pauseScreen;
    public string LevelSelect;
    public GameObject volumeUp, volumeDown;
    public string Level1;
    

    private bool volumeIsUp = true;
       
    private AudioSource[] audioObjects;
  
    void Start()
    {
        audioObjects = FindObjectsOfType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnPause();
        }
        
    }
    public void PauseUnPause()
    {
        if (!pauseScreen.activeInHierarchy)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void VolumeUp()
    {
        if (volumeIsUp)
        {
            return;
        }
        foreach (var volumeObject in audioObjects)
        {
            volumeObject.volume=1f;
        }
        volumeIsUp = true;

    }
    public void VolumeDown()
    {
        if (!volumeIsUp)
        {
            return;
        }
        foreach (var volumeObject in audioObjects)
        {
            volumeObject.volume = 0f;
        }
        volumeIsUp = false;


    }
    public void Settings()
    {
        volumeUp.SetActive(true);
        volumeDown.SetActive(true);
    }

    public void GoToLevelSelect()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(LevelSelect);
    }
    public void Play()
    {
        SceneManager.LoadScene(Level1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
