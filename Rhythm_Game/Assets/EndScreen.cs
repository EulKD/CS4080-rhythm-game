using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndScreen : MonoBehaviour
{
    public TMP_Text ScoreUI = null;
    public TMP_Text HighScoreUI = null;
    void Start()
    {
        if (ScoreUI != null && HighScoreUI != null)
        {
            int score = PlayerPrefs.GetInt("Score", 0);
            int highScore = PlayerPrefs.GetInt("HighScore", 0);
            Debug.Log(score.ToString());
            ScoreUI.text = "Score: " + score;

            if (score > highScore)
            {
                highScore = score;
                PlayerPrefs.SetInt("HighScore", score);
            }
            HighScoreUI.text = "High Score: " + highScore.ToString();
        }
    }

    public void Retry()
    {
        // Hardcoded to the single level
        SceneManager.LoadScene("PlaySong1");
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }

}
