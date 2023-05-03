using System;
using TMPro;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    // https://docs.unity3d.com/ScriptReference/Color.HSVToRGB.html
    // https://docs.unity3d.com/ScriptReference/Light-color.html
    
    private Light lt;
    private float m_Value;

    void Start()
    {
        lt = GetComponent<Light>();
    }
    
    void Update()
    {
        lt.color -= (Color.white / 2.0f) * Time.deltaTime;
    }
}
