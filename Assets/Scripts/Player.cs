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
    void FixedUpdate()
    {

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
            var shake = Input.acceleration.magnitude;
            if (shake > shakeThreshold) { 
                shakeMoveSpeed += shake * shakeMultiplier;
            }
            else
            {
                shakeMoveSpeed -= shake * (shakeMultiplier+shakeMultiplier);
                //Godt til threshholds (minder om et if statement) (ser om shakeMoveSpeed er mindre end 0 og s�tter derefter det til 0)
                shakeMoveSpeed = shakeMoveSpeed < 0 ? 0 : shakeMoveSpeed;
            }

            cylinderTransform.Rotate(0, shakeMoveSpeed, 0);
            var textToMoovementSpeed = shakeMoveSpeed * 10;
            moovementSpeed.text = textToMoovementSpeed.ToString("0.00" + "km/t");


            Debug.Log(playerSpeed);
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
}
