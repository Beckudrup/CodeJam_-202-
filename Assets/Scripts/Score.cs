using System;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Inspired by: https://www.youtube.com/watch?v=vZU51tbgMXk
    public static Score Instance;
    public TextMeshProUGUI scoreText, highscoreText, scoreTextEnd, highscoreTextEnd;
    public Player playerScript;

    public float scoreValue; //Accessed by Player.cs though static Instance
    float highscoreValue;
    readonly float distance = 0.5f;
    bool highscoreDeleted;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        highscoreValue = PlayerPrefs.GetFloat("HighScore",0);
        highscoreText.text = $"Highscore: {highscoreValue:n0} m";
        scoreText.text = $"Score: {scoreValue:n0} m";
    }

    void OnEnable()
    {
        GameEvents.GameEnded += SetScoreOnEndScreen;
    }

    void OnDisable()
    {
        GameEvents.GameEnded -= SetScoreOnEndScreen;
    }

    void Update()
    {
        scoreValue += distance * playerScript.shakeMoveSpeed;
        scoreText.text = $"Score: {scoreValue:n0} m";
        UpdateHighScore();
        SetScoreOnEndScreen();
    }

    void SetScoreOnEndScreen()
    {
        scoreTextEnd.text = $"Score: \n{scoreValue:n0} m";
        highscoreTextEnd.text = $"Highscore: \n{highscoreValue:n0} m";
    }

    void UpdateHighScore()
    {
        highscoreValue = PlayerPrefs.GetFloat("HighScore",0);
        if (highscoreDeleted) return;
        highscoreText.text = $"Highscore: {highscoreValue:n0} m";
        if (highscoreValue < scoreValue)
        {
            PlayerPrefs.SetFloat("HighScore", scoreValue);
        }
    }
    
    public void DeleteHighscore() //Accessed by DeleteHighscore Button.
    {
        highscoreDeleted = true;
        PlayerPrefs.DeleteAll();
    }
}

