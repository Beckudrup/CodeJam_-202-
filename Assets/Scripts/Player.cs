using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Player : MonoBehaviour
{
<<<<<<< Updated upstream
    [SerializeField] int playerSpeed = 1;
    Transform cylinderTransform;
=======
    public TMP_Text moovementSpeed; //Cows speed 
    [SerializeField] private GameObject LeftButton, RightButton;

>>>>>>> Stashed changes

    // Start is called before the first frame update
    void awake()
    {
        cylinderTransform = GameObject.Find("Cylinder").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
<<<<<<< Updated upstream
        cylinderTransform.Rotate(0, playerSpeed * Time.deltaTime, 0);
=======
        if(LeftButton && RightButton)
        {
            float tilt = Input.acceleration.y;
            moovementSpeed.text = tilt.ToString("0.00");

        }
>>>>>>> Stashed changes
    }
}
