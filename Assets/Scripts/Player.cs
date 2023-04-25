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
            playerSpeed = Input.acceleration.y*50;
            if (playerSpeed <= 0)
                playerSpeed *= -1;
            //moovementSpeed.text = Input.accelerationEventCount.ToString("0.00");
            moovementSpeed.text = playerSpeed.ToString("0.00"); //Kommenteret ud for nu da det kun virker på mobil
            cylinderTransform.Rotate(0, playerSpeed * Time.deltaTime, 0);
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
