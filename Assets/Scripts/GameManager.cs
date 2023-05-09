using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public ObstacleSpwaner obstacleSpwaner;
    public SpaceShipSwipeScript spaceShipSwipeScript;

    private int currentScore = 0;

    private int Bestscore;
    private int randomCounter;


    private bool HoldGame = true;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(RandomCounterCoroutine());
    }

    IEnumerator RandomCounterCoroutine()
    {
        WaitForSeconds wait = new WaitForSeconds(1f);

        while (true)
        {
            if (!HoldGame)
            {
                randomCounter++;
                UIManager.instance.SetRandomtext(randomCounter);
            }
            yield return wait;
        }
    }
    private void OnEnable()
    {
        Bestscore = PlayerPrefs.GetInt("BestScore");
        UIManager.instance.setBestScore(Bestscore);
    }
   
    public void StartGame()
    {
        if (obstacleSpwaner == null && spaceShipSwipeScript == null)
            Debug.Log("Reference Uninitialize");

        obstacleSpwaner.enabled = true;

        spaceShipSwipeScript.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        spaceShipSwipeScript.enabled = true;
    }

    public void StopGame()
    {
        if (obstacleSpwaner == null && spaceShipSwipeScript == null)
            Debug.Log("Reference Uninitialize");

        obstacleSpwaner.enabled = false;
        spaceShipSwipeScript.enabled = false;
    }

    public void SetCoin()
    {
        currentScore++;
        UIManager.instance?.SetScoreText(currentScore);
        
        if(currentScore > Bestscore)
        {
            Bestscore = currentScore;
            PlayerPrefs.SetInt("BestScore", Bestscore);
            UIManager.instance.setBestScore(Bestscore);
        }
        else
        {
            UIManager.instance.setCurrentScore(currentScore);
        }
    }

    public void RestartGame()
    {
        randomCounter = 0;
        UIManager.instance.SetRandomtext(randomCounter);
        SceneManager.LoadScene(0);
    }

    public void PlayerDied()
    {
        UIManager.instance.InactiveActivateScorePanel(true);
        obstacleSpwaner.StopAllCoroutines();
        obstacleSpwaner.enabled = false;
        spaceShipSwipeScript.enabled = false;
        HoldGame = true;

    }

    public void profilebtnclicked()
    {
        Time.timeScale = 0f;
        UIManager.instance.InactiveActivateProfilePanel(true);
        UIManager.instance.setBestScore_profile(PlayerPrefs.GetInt("BestScore"));
        UIManager.instance.StartGameBtnActiveInactive(false);
    }

    public void Exitbtnclicked()
    {
        Time.timeScale = 1f;
        UIManager.instance.InactiveActivateProfilePanel(false);
        UIManager.instance.StartGameBtnActiveInactive(true);
    }

    public void StartGame_clicked()
    {
        UIManager.instance?.DisableEnableTapStartGameText(false);
        UIManager.instance.StartGameBtnActiveInactive(false);
        HoldGame = false;
        randomCounter = 0;
        UIManager.instance.SetRandomtext(randomCounter);
        StartGame();
    }
}
