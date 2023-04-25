using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    [SerializeField] GameObject startButton, hornButtons;
    [SerializeField] Animator cowCam;
    [SerializeField] int camStartSize = 0, camEndSize = 70;
    
    bool startButtonPressed;
    
    void Start()
    {
        hornButtons.SetActive(false);
        mainCam.fieldOfView = camStartSize;
    }

    void Update()
    {
        if (mainCam.fieldOfView < camEndSize - 1) return;
        hornButtons.SetActive(true);
    }

    public void StartGame()
    {
        cowCam.SetTrigger("StartGame");
        startButton.SetActive(false);
    }

    public void EndGame() //Only public to be access by test button 
    {
        cowCam.SetTrigger("GameFinish");
    }
}
