using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    [SerializeField] GameObject startButton;
    [SerializeField] int camMenu = 0;
    [SerializeField] int camStart = 70;
    [SerializeField] float camSpeed;
    bool buttonPressed;
    
    void Start()
    {
        mainCam.fieldOfView = camMenu;
    }

    void Update()
    {
        if (!buttonPressed) return;
        var newCamSize = Mathf.Lerp(mainCam.fieldOfView, camStart, Time.deltaTime * camSpeed);
        mainCam.fieldOfView = newCamSize;
        if (Math.Abs(mainCam.fieldOfView - camStart) > 5) return;
        buttonPressed = false;
    }

    public void StartGame()
    {
        buttonPressed = true;
        startButton.SetActive(false);
    }
}
