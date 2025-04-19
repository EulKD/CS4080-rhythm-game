using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    int multiplier = 1;
    int streak = 0;

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
            Destroy(col.gameObject); // Remove the missed note
        }
    }

    public void AddStreak()
    {
        if(PlayerPrefs.GetInt("Meter")+1<50)
        {
            PlayerPrefs.SetInt("Meter", PlayerPrefs.GetInt("Meter") + 1);
        }

        streak++;

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

        //if (streak >= 30) multiplier = 4;
        //else if (streak >= 20) multiplier = 3;
        //else if (streak >= 10) multiplier = 2;
        //else multiplier = 1;

        UpdateGUI();
    }

    public void ResetStreak()
    {
        if (PlayerPrefs.GetInt("Meter") < 0)
        {
            Lose();
        }

        PlayerPrefs.SetInt("Meter", PlayerPrefs.GetInt("Meter") - 2);
        streak = 0;
        multiplier = 1;
        UpdateGUI();
    }

    void UpdateGUI()
    {
        PlayerPrefs.SetInt("Streak",streak);
        PlayerPrefs.SetInt("Mult",multiplier);
    }

    void Lose()
    {
        print("game lost");
    }

    public void Win()
    {
        print("game won");
    }

    public int GetScore()
    {
        return 10 * multiplier;
    }

}
