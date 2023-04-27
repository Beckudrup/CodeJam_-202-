using UnityEngine;

// Inspiration from: https://gamedevbeginner.com/billboards-in-unity-and-how-to-make-your-own/
public class Billboard : MonoBehaviour
{
    Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }

    void LateUpdate()
    {
        transform.LookAt(mainCamera.transform);
        transform.Rotate(0, 180, 0);
    }
}
