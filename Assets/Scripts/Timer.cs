using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public float timer = 10.0f;

    // Update is called once per frame
    void Update()
    {
        //if(LeftButton && RightButton)
        //{

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            //Spil animation og stop lvl
        }
        //}

    }
}
