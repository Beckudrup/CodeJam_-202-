using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    public TMP_Text timer;
    public float timeLeft = 10.0f;
    [SerializeField] private GameObject LeftHorn, RightHorn;
    public bool leftButton, rightButton;
    // Update is called once per frame
    void Update()
    {
        if(leftButton && rightButton)
        {

        timeLeft -= Time.deltaTime;
        timer.text = timeLeft.ToString("0.00"); //Kommenteret ud for nu da det kun virker på mobil
        if (timeLeft <= 0)
        {
            //Spil animation og stop lvl
            leftButton = false;
            rightButton = false;
        }
        }

    }
    public void LeftButton()
    {
        leftButton = !leftButton;
    }
    public void RightButton()
    {
        rightButton =!rightButton;
    }

}
