using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed = 0;
    Transform cylinderTransform;

    public TMP_Text moovementSpeed; //Cows speed 
    [SerializeField] private GameObject LeftButton, RightButton;


    // Start is called before the first frame update
    void awake()
    {
        cylinderTransform = GameObject.Find("Cylinder").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(LeftButton && RightButton)
        {
            playerSpeed = Input.acceleration.y;
            moovementSpeed.text = playerSpeed.ToString("0.00");
            cylinderTransform.Rotate(0, Input.acceleration.y * Time.deltaTime, 0);

        }
    }
}
