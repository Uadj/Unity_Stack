using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("Main")]
    [SerializeField]
    private GameObject mainPanel;
    [SerializeField]
    private TextMeshProUGUI textCurrentScore;
    [SerializeField]
    private GameObject newRecordText;
    [SerializeField]
    private TextMeshProUGUI HighScore;
    [SerializeField]
    private GameObject CrownImage;
    [SerializeField]
    private GameObject TouchToRestart;
    public void GameStart()
    {
        mainPanel.SetActive(false);

        textCurrentScore.gameObject.SetActive(true);
    }
    public void UpdateScore(int score)
    {
        textCurrentScore.text = score.ToString();
    }
    public void GameOver(bool isNewRecord)
    {
        if(isNewRecord == true)
        {
            newRecordText.SetActive(true);
        }
        else
        {
            CrownImage.SetActive(true);
            HighScore.text = "HighScore : " + PlayerPrefs.GetInt("HighScore").ToString();
            HighScore.gameObject.SetActive(true);
        }
        TouchToRestart.SetActive(true);
    }
}
