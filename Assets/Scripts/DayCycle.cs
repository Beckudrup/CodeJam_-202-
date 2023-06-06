using UnityEngine;

public class DayCycle : MonoBehaviour
{
    // Inspiration from Unity Documentation
    
    // private float hueColor, saturationColor, valueColor;
    // private float redValue, greenValue, blueValue, alphaValue;
    
    [SerializeField] private float duration;
    private Color color0 = Color.white;
    private Color color1 = Color.black;
    
    private Light lt;

    [SerializeField] Timer timerScript;

    void Start()
    {
        lt = GetComponent<Light>(); // Getting the component
    }

    void ColorChange() => lt.color = Color.Lerp(color0, color1, Mathf.PingPong(Time.time, duration) / duration);
    
        // Color.RGBToHSV(new Color(redValue,greenValue,blueValue,alphaValue),
        // out float hueColor, out float saturationColor, out float valueColor);
        // lt.color = Color.HSVToRGB(hueColor, saturationColor, valueColor);
        
        // float t = Mathf.PingPong(Time.time, duration) / duration;
        // lt.color = Color.Lerp(color0, color1, t);

        public void Update()
        {
            if (timerScript.gameStarted == false) return;
            ColorChange();
        }
}