using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    [SerializeField] GameObject startButton, hornButtons;
    [SerializeField] int camMenuSize = 0, camEndSize = 70;
    [SerializeField] float camSpeed;
    bool buttonPressed;
    
    void Start()
    {
        mainCam.fieldOfView = camMenuSize;
    }

    void Update()
    {
        if (!buttonPressed) return;
        var newCamSize = Mathf.Lerp(mainCam.fieldOfView, camEndSize, Time.deltaTime * camSpeed);
        mainCam.fieldOfView = newCamSize;
        if (Math.Abs(mainCam.fieldOfView - camEndSize) > 5) return;
        hornButtons.SetActive(true);
        buttonPressed = false;
    }

    public void StartGame()
    {
        buttonPressed = true;
        startButton.SetActive(false);
    }
}
