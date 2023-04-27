using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenBehacior : MonoBehaviour
{
    bool hitByCow = false;
    float chickenLifeTime = 8f;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        if(other.gameObject.tag == "Player")
        {
            this.transform.SetParent(null);
            hitByCow = true;
            Debug.Log("CHICKEN HIT BY COW!");
            Invoke("RemoveAfterHit", chickenLifeTime);
        }  
        
    }

    private void Update()
    {
        if (hitByCow == true)
        {
            this.transform.position += new Vector3(0,200,1000) * Time.deltaTime;
        }
    }

    void RemoveAfterHit()
    {
        Destroy(this.gameObject);
    }



}
