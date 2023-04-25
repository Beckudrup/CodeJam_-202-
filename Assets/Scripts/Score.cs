using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Inspired by: https://www.youtube.com/watch?v=vZU51tbgMXk
    public TextMeshProUGUI score;
    public TextMeshProUGUI highscore;

    private int distanceTravelled = 100;

    void Start()
    {
        highscore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        score.text = "Score: " + distanceTravelled;
    }

    void Update()
    {
        score.text = "Score: " + distanceTravelled;
    }

    void UpdateHighScore()
    {
        if (distanceTravelled > PlayerPrefs.GetInt("HighScore", 0)) ;
        PlayerPrefs.SetInt("HighScore", distanceTravelled);
    }
}

