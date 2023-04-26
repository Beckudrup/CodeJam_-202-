using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    
    [SerializeField] Camera mainCam;
    [SerializeField] GameObject startButton, hornButtons, endGameButtons, HUDText;
    [SerializeField] Animator cowCamAnimator;
    [SerializeField] int camStartSize = 0, camDefaultSize = 70, camEndGameSize = 25;
    
    bool startButtonPressed;
    bool gameFinished;

    void Awake()
    {
        mainCam.fieldOfView = camStartSize;
        HUDText.SetActive(false);
        endGameButtons.SetActive(false);
        hornButtons.SetActive(false);
    }

    void LateUpdate()
    {
        if (mainCam.fieldOfView > camDefaultSize - 1 && gameFinished == false)
        {
            HUDText.SetActive(true);
            hornButtons.SetActive(true);
        }
        if (mainCam.fieldOfView == camEndGameSize)
            endGameButtons.SetActive(true);
    }

    public void StartGame()
    {
        gameFinished = false;
        cowCamAnimator.SetTrigger("StartGame");
        startButton.SetActive(false);
    }

    public void EndGame() //Only public to be access by test button 
    {
        cowCamAnimator.cullingMode = AnimatorCullingMode.AlwaysAnimate;
        gameFinished = true;
        hornButtons.SetActive(false);
        cowCamAnimator.SetTrigger("GameFinish");
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ViewHighscores()
    {
        //new animation, maybe new scene as well.
    }
}
