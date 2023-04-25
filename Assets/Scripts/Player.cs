using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed = 0;
    //[SerializeField] GameObject cylinder;
    Transform cylinderTransform;

    public TMP_Text moovementSpeed; //Cows speed 
    [SerializeField] private GameObject LeftButton, RightButton;


    // Start is called before the first frame update
    void Awake()
    {
        //cylinderTransform = cylinder.GetComponent < Transform>();
        cylinderTransform = GameObject.Find("Cylinder").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //if(LeftButton && RightButton)
        //{
            playerSpeed = Input.acceleration.y*50;
            moovementSpeed.text = playerSpeed.ToString("0.00");
            cylinderTransform.Rotate(0, playerSpeed * Time.deltaTime, 0);
        Debug.Log(playerSpeed);
        //}
    }
}
