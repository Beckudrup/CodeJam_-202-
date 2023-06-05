using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenDetect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // https://docs.unity3d.com/ScriptReference/Collider.OnTriggerEnter.html 
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            SoundManager.Instance.ChickenWarningSound();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
