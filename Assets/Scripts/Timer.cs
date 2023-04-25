using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    public TMP_Text timer;
    public float timeLeft = 10.0f;

    // Update is called once per frame
    void Update()
    {
        //if(LeftButton && RightButton)
        //{

        timeLeft -= Time.deltaTime;
        timer.text = timeLeft.ToString(0.00);
        if (timeLeft <= 0)
        {
            //Spil animation og stop lvl
        }
        //}

    }
}
