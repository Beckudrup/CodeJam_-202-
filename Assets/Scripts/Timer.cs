using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    public TMP_Text timer;
    public float timeLeft = 10.0f;
    [SerializeField] GameObject leftButton, rightButton, grabText;
    [HideInInspector] public bool leftButtonPressed, rightButtonPressed;

    bool gameStarted, timeStop, gunshotPlayed;
    void Awake()
    {
        var alphaValue = 0;
        timer.alpha = alphaValue;
    }

    public void FixedUpdate()
    {
        StartTime();
        GameIsStated();
        TimeIsUp();
    }

    void StartTime()
    {
        if (timeStop) return;
        if (leftButtonPressed && rightButtonPressed)
        {
            var alphaValue = 1;
            timer.alpha = alphaValue;
            gameStarted = true;
            grabText.SetActive(false);
        }
    }

    void GameIsStated()
    {
        if (gameStarted)
        {
            if (!gunshotPlayed)
            {
                SoundManager.Instance.GunshotSound();
                gunshotPlayed = true;
            }
            timer.text = timeLeft.ToString("0.0");
            timeLeft -= Time.deltaTime;
        }
    }
    
    void TimeIsUp()
    {
        if (timeLeft <= 0 && !timeStop)
        {
            GameEvents.OnTimeIsUp();
            SoundManager.Instance.CowbellSound();
            timeLeft = 0;
            var biggerFontSize = 38;
            timer.fontSize = biggerFontSize;
            timer.text = "Time is up!\n\n\nStop shaking!";
            leftButtonPressed = false;
            rightButtonPressed = false;
            leftButton.SetActive(false);
            rightButton.SetActive(false);
            timeStop = true;
        }
    }

    public void LeftButton()
    {
        leftButtonPressed = !leftButtonPressed;
    }
    public void RightButton()
    {
        rightButtonPressed = !rightButtonPressed;
    }

}
