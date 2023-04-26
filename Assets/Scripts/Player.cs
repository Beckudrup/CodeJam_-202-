using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed = 0;
    Transform cylinderTransform;

    public TMP_Text moovementSpeed; //Cows speed 
    [SerializeField] private GameObject LeftHorn, RightHorn;
    public bool leftButton, rightButton;

    float baseMoveSpeed = 2f;
    float shakeMultiplier = 0.005f;
    public float shakeMoveSpeed;
    float shakeThreshold = 2.0f;


    // Start is called before the first frame update
    void Awake()
    {
        cylinderTransform = GameObject.Find("Cylinder").GetComponent<Transform>();
    }

    // Update is called once per frame
    public void FixedUpdate()
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

    public void Movement()
    {

        if (leftButton && rightButton)
        {

            var shake = Input.acceleration.magnitude;
            if (shake > shakeThreshold)
            {
                shakeMoveSpeed += shake * shakeMultiplier;
            }
            else
            {
                shakeMoveSpeed -= shake * (shakeMultiplier + shakeMultiplier);
                //Godt til threshholds (minder om et if statement) (ser om shakeMoveSpeed er mindre end 0 og s�tter derefter det til 0)
                shakeMoveSpeed = shakeMoveSpeed < 0 ? 0 : shakeMoveSpeed;
            }

            cylinderTransform.Rotate(0, shakeMoveSpeed, 0);
        }
        var textToMoovementSpeed = shakeMoveSpeed * 10;
        moovementSpeed.text = textToMoovementSpeed.ToString("0.00" + "km/t");
    }
}
