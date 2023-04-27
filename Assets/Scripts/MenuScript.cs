using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField] Image milkshake;
    [SerializeField] Score score;
    [SerializeField] Camera mainCam;
    [SerializeField] GameObject startButton, hornButtons, HUDText, endScreen;
    [SerializeField] Animator cowCamAnimator;
    [SerializeField] int camStartSize = 0, camDefaultSize = 70, camEndGameSize = 25;

    float time;
    bool startButtonPressed;
    bool gameFinished;

    void Awake()
    {
        mainCam.fieldOfView = camStartSize;
        HUDText.SetActive(false);
        hornButtons.SetActive(false);
        endScreen.SetActive(false);
    }

    void LateUpdate()
    {
        if (mainCam.fieldOfView > camDefaultSize - 1 && gameFinished == false)
        {
            HUDText.SetActive(true);
            hornButtons.SetActive(true);
        }
    }

    public void StartGame()
    {
        gameFinished = false;
        cowCamAnimator.SetTrigger("StartGame");
        startButton.SetActive(false);
    }

    public void EndGame()
    {
        cowCamAnimator.cullingMode = AnimatorCullingMode.AlwaysAnimate;
        gameFinished = true;
        hornButtons.SetActive(false);
        HUDText.SetActive(false);
        endScreen.SetActive(true);
        score.SetScoreOnEndScreen();
        cowCamAnimator.SetTrigger("GameFinish");
        var delay = 0.1f;
        Invoke(nameof(MilkshakeFill), delay);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    public void DeleteHighscores()
    {
        PlayerPrefs.DeleteAll();
    }
    
    void MilkshakeFill()
    {
        var milkshakeStart = 0f;
        var scoreToMilkshake = 1000f;
        var milkshakeTarget = score.scoreValue / scoreToMilkshake;
        time += Time.deltaTime;
        var duration = 2f;
        milkshake.fillAmount = Mathf.Lerp(milkshakeStart, milkshakeTarget, time / duration);
    }
}
