using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenDetect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // inspired from https://docs.unity3d.com/ScriptReference/Collider.OnTriggerEnter.html 
    private void OnTriggerEnter(Collider other) 
    {

        if (other.gameObject.tag == "Player")
        {
            SoundManager.Instance.ChickenWarningSound();
        }
    }// when entering boxcollider, (sitting as child on Chicken), with COW play this Chicken Sound. 

    // pro, indicate chicken.
    // Con of this, depending on high speed it might not be useful, from where the collider is placed.
    // EHS medium speed, is tested and works fine. ((the hospital can also work as a indication)

   
}
