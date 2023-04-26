using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Inspired by: https://www.youtube.com/watch?v=vZU51tbgMXk
    public TMP_Text score;
    public TextMeshProUGUI highscore;
    public Player playerScript;
   
    private float distance = 0.5f;
    private float distanceTravelled;
    

    void Start()
    {
        highscore.text = "Highscore: " + PlayerPrefs.GetInt("HighScore", 0);
        score.text = "Score: " + distanceTravelled + " m";
    }

    void Update()
    {
        distanceTravelled += distance * playerScript.shakeMoveSpeed;
        //distanceTravelled += distance * 2;

        score.text = "Score: " + distanceTravelled.ToString("0") + "m";

        //highscore.text= highscore< distanceTravelled ? distanceTravelled : highscore.text;


    }

    void UpdateHighScore()
    { // Måske skal distancetravelled være score.text
        if (distanceTravelled > PlayerPrefs.GetInt("HighScore", 0))
        PlayerPrefs.SetFloat("HighScore", distanceTravelled);
    }
}

