using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class Timer : MonoBehaviour
{
    public TMP_Text timer;
    public float timeLeft = 10.0f;
    [SerializeField] GameObject leftButton, rightButton, grabText;
    [HideInInspector] public bool leftButtonPressed, rightButtonPressed;

    bool gameStarted;
    bool timeStop;
    // Update is called once per frame
    void Awake()
    {
        var alphaValue = 0;
        timer.alpha = alphaValue;
    }

    public void FixedUpdate()
    {
        if (timeStop) return;
        if (leftButtonPressed && rightButtonPressed)
        {
            //alpha is the transparentsy of the timer goes from 0 to 1,
            var alphaValue = 1;
            timer.alpha = alphaValue;
            gameStarted = true;
            grabText.SetActive(false);
        }

        if (gameStarted)
        {
            
            timer.text = timeLeft.ToString("0.0"); //Kommenteret ud for nu da det kun virker p� mobil
            timeLeft -= Time.deltaTime;
        }

      
        if (timeLeft <= 0)
        {
            SoundManager.Instance.CowbellSound();
            timeLeft = 0;
            timer.text = "Time is up!\n\nStop shaking!";
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
