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
   
    private float distance = 0.5f;
    private float distanceTravelled;

    void Start()
    {
        highscore.text = "Highscore: " + PlayerPrefs.GetInt("HighScore", 0);
    }

    void Update()
    {
        distanceTravelled += distance * playerScript.shakeMoveSpeed;
        score.text = "Score: " + distanceTravelled + " meters travelled";
    }

    void UpdateHighScore()
    { // Måske skal distancetravelled være score.text
        if (distanceTravelled > PlayerPrefs.GetInt("HighScore", 0)) ;
        PlayerPrefs.SetFloat("HighScore", distanceTravelled);
    }
}

