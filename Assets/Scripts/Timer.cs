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
            if (timeLeft <= 0)
            {
                //Spil animation og stop lvl
                leftButton = false;
                rightButton = false;
            }
            else
            {
                timer.text = timeLeft.ToString("0.0"); //Kommenteret ud for nu da det kun virker på mobil

                timeLeft -= Time.deltaTime;

            }

        }

    }
    public void LeftButton()
    {
        leftButton = true;
    }
    public void RightButton()
    {
        rightButton = true;
    }

}
