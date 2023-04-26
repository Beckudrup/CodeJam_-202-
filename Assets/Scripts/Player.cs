using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Player : MonoBehaviour
{
    Camera mainCam;
    int maxCamFOV = 150, minCamFOV = 70;
    Transform cylinderTransform;
    Animator cowCamAnimator;
    [SerializeField] TMP_Text moovementSpeed; //Cows speed 
    [SerializeField] GameObject LeftHorn, RightHorn;
    [HideInInspector] public bool leftButton, rightButton;

    float baseMoveSpeed = 2f;
    float shakeMultiplier = 0.005f;
    [HideInInspector] public float shakeMoveSpeed;
    float shakeThreshold = 2.0f;
    float shake;


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

        if (leftButton && rightButton)
            {
            /*
            playerSpeed = Input.acceleration.y*50;
            if (playerSpeed <= 0)
                playerSpeed *= -1;
            /*moovementSpeed.text = Input.accelerationEventCount.ToString("0.00");
            moovementSpeed.text = playerSpeed.ToString("0.00"); //Kommenteret ud for nu da det kun virker p� mobil
            cylinderTransform.Rotate(0, playerSpeed * Time.deltaTime, 0);
            */
            shake = Input.acceleration.magnitude;
            cowCamAnimator.SetTrigger("isRiding"); 
            cowCamAnimator.cullingMode = AnimatorCullingMode.CullUpdateTransforms;
            if (shake > shakeThreshold) { 
                shakeMoveSpeed += shake * shakeMultiplier;
                DistortCamera();
            }
            else
            {
                shakeMoveSpeed -= shake * (shakeMultiplier+shakeMultiplier);
                UnDistortCamera();
                //Godt til threshholds (minder om et if statement) (ser om shakeMoveSpeed er mindre end 0 og s�tter derefter det til 0)
                shakeMoveSpeed = shakeMoveSpeed < 0 ? 0 : shakeMoveSpeed;
            }

            cylinderTransform.Rotate(0, shakeMoveSpeed, 0);
            
            var textToMoovementSpeed = shakeMoveSpeed * 10;
            moovementSpeed.text = textToMoovementSpeed.ToString("0.00") + " km/t";
            }
    }
    public void LeftButton()
    {
        leftButton = !leftButton;
    }
    public void RightButton()
    {
        rightButton = !rightButton;
    }
    
    void DistortCamera()
    {
        mainCam.fieldOfView += shakeMoveSpeed/5;
        mainCam.fieldOfView = mainCam.fieldOfView > maxCamFOV ? maxCamFOV : mainCam.fieldOfView;
        //mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, maxCamFOV, shakeMoveSpeed * Time.deltaTime);
    }

    void UnDistortCamera()
    {
        mainCam.fieldOfView -= shakeMoveSpeed / 10;
        mainCam.fieldOfView = mainCam.fieldOfView < minCamFOV ? minCamFOV : mainCam.fieldOfView;
        //mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, minCamFOV, shakeMoveSpeed * Time.deltaTime);
    }

    void Movement()
    {
        if (leftButton && rightButton)
        {
            var shake = Input.acceleration.magnitude;
            cowCamAnimator.SetTrigger("isRiding");
            if (shake > shakeThreshold)
            {
                shakeMoveSpeed += shake * shakeMultiplier;
                cylinderTransform.Rotate(0, shakeMoveSpeed, 0);

            }
            else
            {
                slowDown();
                cylinderTransform.Rotate(0, shakeMoveSpeed, 0);

            }
        }
        else
        {
            slowDown();
            cylinderTransform.Rotate(0, shakeMoveSpeed, 0);

        }

        var textToMoovementSpeed = shakeMoveSpeed * 10;
        moovementSpeed.text = textToMoovementSpeed.ToString("0.00") + " km/t";
    }
    void slowDown()
    {
        shakeMoveSpeed -= (shakeMultiplier + shakeMultiplier);
        //Godt til threshholds (minder om et if statement) (ser om shakeMoveSpeed er mindre end 0 og s�tter derefter det til 0)
        shakeMoveSpeed = shakeMoveSpeed < 0 ? 0 : shakeMoveSpeed;
    }
}
