using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Player : MonoBehaviour
{
    public MenuScript menuScript;
    public Timer timer;
    Camera mainCam;
    int maxCamFOV = 130, minCamFOV = 70;
    Transform cylinderTransform;
    Animator cowCamAnimator;
    [SerializeField] TMP_Text moovementSpeed; //Cows speed 
    [SerializeField] GameObject LeftHorn, RightHorn;
    [HideInInspector] public bool leftButton, rightButton;

    float baseMoveSpeed = 2f;
    float shakeMultiplier = 0.002f;
    public float shakeMoveSpeed;
    float shakeThreshold = 2f;
    float shake;
    float moovementSpeedValue;


    // Start is called before the first frame update
    void Awake()
    {
        mainCam = Camera.main;
        cowCamAnimator = GetComponent<Animator>();
        cylinderTransform = GameObject.Find("Cylinder").GetComponent<Transform>();
    }

    void LateUpdate()
    {
        if (shake > shakeThreshold) { 
            mainCam.fieldOfView += shakeMoveSpeed * Time.deltaTime;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }
    public void LeftButton()
    {
        leftButton = !leftButton;
    }
    public void RightButton()
    {
        rightButton = !rightButton;
    }

    void Movement()
    {
        if (timer.timeLeft <= 0)
        {
            leftButton = false;
            rightButton = false;
            shake = 0;
            if(shakeMoveSpeed == 0)
                menuScript.EndGame();
        }
        if (leftButton && rightButton)
        {
            cowCamAnimator.cullingMode = AnimatorCullingMode.CullUpdateTransforms;
            shake = Input.acceleration.magnitude;
            cowCamAnimator.SetTrigger("isRiding");
            if (shake > shakeThreshold)
            {
                shakeMoveSpeed += shake * shakeMultiplier;
                cylinderTransform.Rotate(0, shakeMoveSpeed, 0);
                DistortCamera();
            }
            else
            {
                SlowDown();
                cylinderTransform.Rotate(0, shakeMoveSpeed, 0);
                UnDistortCamera();
            }
        }
        else
        {
            SlowDown();
            cylinderTransform.Rotate(0, shakeMoveSpeed, 0);
            UnDistortCamera();
        }

        moovementSpeedValue = shakeMoveSpeed * 35;
        moovementSpeed.text = moovementSpeedValue.ToString("0.00") + " km/t";
    }
    void SlowDown()
    {
        shakeMoveSpeed -= shakeMultiplier + shakeMultiplier;
        //Godt til threshholds (minder om et if statement) (ser om shakeMoveSpeed er mindre end 0 og sætter derefter det til 0)
        if (timer.timeLeft <= 0)
        {
            shakeMoveSpeed -= shakeMultiplier * 2;
        }
        shakeMoveSpeed = shakeMoveSpeed < 0 ? 0 : shakeMoveSpeed;
    }
    
    void DistortCamera()
    {
        mainCam.fieldOfView = minCamFOV + moovementSpeedValue/3; //Magic number is a stabilizer to make the fov to increase faster
        mainCam.fieldOfView = mainCam.fieldOfView > maxCamFOV ? maxCamFOV : mainCam.fieldOfView;
        //mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, maxCamFOV, shakeMoveSpeed / 10);
    }

    void UnDistortCamera()
    {
        mainCam.fieldOfView = minCamFOV + moovementSpeedValue/3; //Magic number is a stabilizer to make the fov to decrease slower
        mainCam.fieldOfView = mainCam.fieldOfView < minCamFOV ? minCamFOV : mainCam.fieldOfView;
        //mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, minCamFOV, shakeMoveSpeed / 10);
    }
}
