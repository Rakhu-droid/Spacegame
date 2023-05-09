using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text coinText;
    [SerializeField] TMP_Text RandomText;
    [SerializeField] TMP_Text TapGameText;
    [SerializeField] GameObject scorePanel;
    [SerializeField] GameObject profilepanel;
    [SerializeField] GameObject startgamebutton;
    [SerializeField] TMP_Text bestscoretext;
    [SerializeField] TMP_Text bestscoretext_profile;
    [SerializeField] TMP_Text currentscoretext;

   public static UIManager instance;


    private void OnEnable()
    {
        DisableEnableTapStartGameText(true);
    }
    private void Awake()
    {
        instance = this;
    }

    public void SetScoreText(int scorecounter)
    {
        if (coinText == null)
        {
            Debug.Log("coin text reference is empty");
            return;
        }

        coinText.text = scorecounter.ToString();
    }

    public void DisableEnableTapStartGameText(bool canshow)
    {
        if (TapGameText == null)
        {
            Debug.Log("TapGameText reference is empty");
            return;
        }

        TapGameText.gameObject.SetActive(canshow);
    }

    public void SetRandomtext(int randomcounter)
    {
        RandomText.text = randomcounter.ToString();
    }
    public void InactiveActivateScorePanel(bool canshow)
    {
        if (scorePanel == null)
        {
            Debug.Log("score panel reference is empty");
            return;
        }

        scorePanel.SetActive(canshow);
    }

    public void setBestScore(int bestscore)
    {
       bestscoretext.text = "Best Score: " + bestscore.ToString();
    }
    public void setCurrentScore(int currentscore)
    {
        currentscoretext.text = "Current Score: " + currentscore.ToString();
    }
    public void InactiveActivateProfilePanel(bool canshow)
    {
        if (profilepanel == null)
        {
            Debug.Log("profilepanel reference is empty");
            return;
        }

        profilepanel.SetActive(canshow);
    }

    public void setBestScore_profile(int bestscore)
    {
        bestscoretext_profile.text = "Best Score: " + bestscore.ToString();
    }

    public void StartGameBtnActiveInactive(bool canshow)
    {
        if (startgamebutton == null)
        {
            Debug.Log("startgamebutton reference is empty");
            return;
        }

        startgamebutton.SetActive(canshow);
    }
}
