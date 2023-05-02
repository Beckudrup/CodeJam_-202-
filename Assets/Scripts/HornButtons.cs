using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornButtons : MonoBehaviour
{

    [SerializeField] GameObject leftButton, rightButton;
    public bool buttonsPressed = false;
    public bool leftHornButton = false;
    public bool rightHornButton = false;
    [SerializeField] GameObject rightHornButtonGraphic, leftHornButtonGraphic;

    public void LeftButton()
    {
        leftHornButton = !leftHornButton;
        leftHornButtonGraphic.SetActive(!leftHornButton);
    }
    public void RightButton()
    {
        rightHornButton = !rightHornButton;
        rightHornButtonGraphic.SetActive(!rightHornButton);

    }
}
