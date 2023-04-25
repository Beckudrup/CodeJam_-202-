using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int playerSpeed = 1;
    Transform cylinderTransform;

    // Start is called before the first frame update
    void Start()
    {
        cylinderTransform = GameObject.Find("Cylinder").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        cylinderTransform.Rotate(0, playerSpeed * Time.deltaTime, 0);
    }
}
