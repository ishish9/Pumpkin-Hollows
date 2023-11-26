using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private TextMeshProUGUI SBHigh_Display;
    [SerializeField] private TextMeshProUGUI SBHigh_Submit_Display;
    [SerializeField] private TextMeshProUGUI SB_Display;
    private int CurrentScore = 0;
    private int HighScore;

    public void SetHighScore()
    {
        HighScore = PlayerPrefs.GetInt("HighScore");
        SBHigh_Display.text = HighScore.ToString();
    }

    public void Scoreupdate()
    {
        ScoreText.text = CurrentScore.ToString();
    }

    public void ScoreAdd1(int AddAmount)
    {
        CurrentScore += AddAmount;
        Scoreupdate();
    }

    public void ResetScore()
    {
        CurrentScore = 0;
        Scoreupdate();
    }

    public void ScoreBoard()
    {
        SB_Display.text = CurrentScore.ToString();

        if (CurrentScore > HighScore)
        {
            HighScore = CurrentScore;
            SBHigh_Display.text = CurrentScore.ToString();
            SBHigh_Submit_Display.text = CurrentScore.ToString();
            PlayerPrefs.SetInt("HighScore", HighScore);
            PlayerPrefs.Save();
        }
    }

    
}
