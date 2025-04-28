using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    int multiplier = 1;
    int streak = 0;
    public string gameOverScene = "GameOverScene";
    public string winScene = "WinScene";

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("Meter", 25);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Note"))
        {
            // If the note reaches the GameManager without being hit, reset streak
            ResetStreak();
            Destroy(col.gameObject);
        }
    }

    public void AddStreak()
    {
        if(PlayerPrefs.GetInt("Meter")+1<=25) // Set max limit for meter
        {
            PlayerPrefs.SetInt("Meter", PlayerPrefs.GetInt("Meter") + 1);   // Increase meter
        }

        streak++;   // Increment streak

        // Multiplier cases
        switch (streak)
        {
            case int s when s >= 20:
                multiplier = 4;
                break;
            case int s when s >= 10:
                multiplier = 3;
                break;
            case int s when s >= 5:
                multiplier = 2;
                break;
            default:
                multiplier = 1;
                break;
        }

        UpdateGUI();
    }

    public void ResetStreak()
    {
        // Lose when meter reaches 0
        if (PlayerPrefs.GetInt("Meter") <= 0)
        {
            Lose();
            return;
        }

        // Decrease on missed note and reset streak
        PlayerPrefs.SetInt("Meter", PlayerPrefs.GetInt("Meter") - 2);
        streak = 0;
        multiplier = 1;
        UpdateGUI();
    }
    
    // Update streak and multiplier text
    void UpdateGUI()
    {
        PlayerPrefs.SetInt("Streak",streak);
        PlayerPrefs.SetInt("Mult",multiplier);
    }

    // Go to lose screen
    void Lose()
    {
        Debug.Log("Game lost - loading game over scene");
        SceneManager.LoadScene(gameOverScene);
    }

    // Go to win screen
    public void Win()
    {
        Debug.Log("Game won - loading win scene");
        SceneManager.LoadScene(winScene);
    }

    // Calculate score
    public int GetScore()
    {
        return 10 * multiplier;
    }

}
