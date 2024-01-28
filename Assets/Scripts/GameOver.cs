using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    
    public Image level;
    public TMP_Text levelText;
    public GameObject levelTextObj;
    public GameObject TryAgainButtonObj;
    public Image player;

    float AnimationSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.PlaySound(0);
        levelText.text = "Level " + PlayerPrefs.GetInt("Level").ToString();
        player.transform.DOMove(new Vector3(player.transform.position.x, 350, player.transform.position.z), 5)
            .OnComplete(() =>
            {
                // This code will be executed when the move is complete
                // You can add additional actions here if needed
                Debug.Log("Player move completed!");

                // If you want to loop the movement, you can uncomment the line below
                // MovePlayerBack();
            });
        player.DOFade(5, 4);

        StartCoroutine(FadeAnim());
        TryAgainButtonObj.transform.DOShakeRotation(5,35,5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator FadeAnim()
    {
        while (true)
        {
            levelTextObj.transform.DOScale(Vector3.one * 1.25f, AnimationSpeed);
            yield return new WaitForSeconds(AnimationSpeed);
            levelTextObj.transform.DOScale(Vector3.one, AnimationSpeed);
            yield return new WaitForSeconds(AnimationSpeed);
        }
    }
    private void OnDisable()
    {
        levelTextObj.transform.DOKill();
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("Home");
    }
}
