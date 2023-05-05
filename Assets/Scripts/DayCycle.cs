using System;
using TMPro;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    // Inspiration from Unity Documentation: https://docs.unity3d.com/ScriptReference/Color.HSVToRGB.html
    // Inspiration from Unity Documentation: https://docs.unity3d.com/ScriptReference/Light-color.html

    [SerializeField] private float duration;
    
    private Color color0 = Color.red;
    private Color color1 = Color.yellow;
    
    private Color color3 = Col
    
    private Light lt;

    void Start()
    {
        lt = GetComponent<Light>(); // Getting the component
    }

    private void Update()
    {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        lt.color = Color.Lerp(color0, color1, t);
    }

    // public void ChangeColor()
    // {
    //     float t = Mathf.PingPong(Time.time, duration) / duration;
    //     lt.color = Color.Lerp(color0, color1, t);
    // }
}
