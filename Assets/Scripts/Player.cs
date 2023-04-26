using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Player : MonoBehaviour
{
    Camera mainCam;
    int maxCamDistance = 150, minCamDistance = 70;
    Transform cylinderTransform;
    Animator cowAnimator;
    [SerializeField] TMP_Text moovementSpeed; //Cows speed 
    [SerializeField] GameObject LeftHorn, RightHorn;
    [HideInInspector] public bool leftButton, rightButton;

    float baseMoveSpeed = 2f;
    float shakeMultiplier = 0.005f;
    [HideInInspector] public float shakeMoveSpeed;
    float shakeThreshold = 2.0f;


    // Start is called before the first frame update
    void Awake()
    {
        mainCam = Camera.main;
        cowAnimator = GetComponent<Animator>();
        cylinderTransform = GameObject.Find("Cylinder").GetComponent<Transform>();
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


    private void Movement()
    {
        if (leftButton && rightButton)
        {
            var shake = Input.acceleration.magnitude;
            cowAnimator.SetTrigger("isRiding");
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
    private void slowDown()
    {
        shakeMoveSpeed -= (shakeMultiplier + shakeMultiplier);
        //Godt til threshholds (minder om et if statement) (ser om shakeMoveSpeed er mindre end 0 og s�tter derefter det til 0)
        shakeMoveSpeed = shakeMoveSpeed < 0 ? 0 : shakeMoveSpeed;
    }
}
