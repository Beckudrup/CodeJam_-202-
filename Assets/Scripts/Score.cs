using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Inspired by: https://www.youtube.com/watch?v=vZU51tbgMXk
    public TextMeshProUGUI score;
    public TextMeshProUGUI highscore;
    public Player playerScript;
    public Timer timer;

    float distance = 0.5f;
    float scoreValue;
    int highscoreValue;

    void Start()
    {
        highscoreValue = PlayerPrefs.GetInt("HighScore",0);
        highscore.text = "Highscore: " + PlayerPrefs.GetInt("HighScore", 0);
        score.text = "Score: " + scoreValue + " m";

    }

    void Update()
    {
        scoreValue += distance * playerScript.shakeMoveSpeed;
        score.text = "Score: " + scoreValue.ToString("0") + " m";

        highscore.text = highscoreValue < scoreValue ? "Highscore: "+scoreValue.ToString("0") + " m": highscore.text;
    }

    void UpdateHighScore()
    { // Måske skal distancetravelled være score.text
        
        if (scoreValue > PlayerPrefs.GetInt("HighScore", 0) && timer.timeLeft<=0.2)
            PlayerPrefs.SetFloat("HighScore", scoreValue);
        highscore.text = PlayerPrefs.GetInt("HighScore", 0).ToString("0");

    }
}

