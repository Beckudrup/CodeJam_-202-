using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneryBehaviour : MonoBehaviour
{
    //script inspired by Learning C# pp. 193

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Deadzone")
        {
            Destroy(gameObject);
        }
    }
}
