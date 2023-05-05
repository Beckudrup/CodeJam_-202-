using System;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    public TMP_Text timer;
    public float timeLeft = 10.0f;
    [SerializeField] GameObject leftButton, rightButton, grabText;
    [HideInInspector] public bool leftButtonPressed, rightButtonPressed;

    bool gameStarted;
    // Update is called once per frame
    void Awake()
    {
        timer.alpha = 0;
    }

    public void FixedUpdate()
    {
        if (leftButtonPressed)
        {
            timer.alpha = 1;
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
            timeLeft = 0;
            timer.text = "Time is up!\n\nStop shaking!";
            leftButtonPressed = false;
            rightButtonPressed = false;
            leftButton.SetActive(false);
            rightButton.SetActive(false);
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
