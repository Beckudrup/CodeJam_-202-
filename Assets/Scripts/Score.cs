using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Inspired by: https://www.youtube.com/watch?v=vZU51tbgMXk
    public TextMeshProUGUI score;
    public TextMeshProUGUI highscore;
    public TextMeshProUGUI scoreEnd;
    public TextMeshProUGUI highscoreEnd;
    public Player playerScript;

    float distance = 0.5f;
    public float scoreValue;
    float highscoreValue;

    bool highscoreDeleted;
    

    void Start()
    {
        highscoreValue = PlayerPrefs.GetFloat("HighScore",0);
        highscore.text = $"Highscore: {highscoreValue:n0} m";
        score.text = $"Score: {scoreValue:n0} m";
    }

    void Update()
    {
        scoreValue += distance * playerScript.shakeMoveSpeed;
        score.text = $"Score: {scoreValue:n0} m";
        UpdateHighScore();
        SetScoreOnEndScreen();
    }

    public void SetScoreOnEndScreen()
    {
        scoreEnd.text = $"Score: \n{scoreValue:n0} m";
        highscoreEnd.text = $"Highscore: \n{highscoreValue:n0} m";
    }

    void UpdateHighScore()
    {
        highscoreValue = PlayerPrefs.GetFloat("HighScore",0);
        if (highscoreDeleted) return;
        highscore.text = $"Highscore: {highscoreValue:n0} m";
        if (highscoreValue < scoreValue)
        {
            PlayerPrefs.SetFloat("HighScore", scoreValue);
        }
    }
    
    public void DeleteHighscore()
    {
        highscoreDeleted = true;
        PlayerPrefs.DeleteAll();
    }
}

