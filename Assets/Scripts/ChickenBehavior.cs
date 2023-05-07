using UnityEngine;

public class ChickenBehavior : MonoBehaviour
{
    bool hitByCow;
    float chickenLifeTime = 8f;
    int chickenNewYPos = 200;
    int chickenNewZPos = 1000;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SoundManager.Instance.ChickenSound();
            transform.SetParent(null);
            hitByCow = true;
            Invoke("RemoveAfterHit", chickenLifeTime);
        }
    }

    void Update()
    {
        if (hitByCow)
        {
            transform.position += new Vector3(0,chickenNewYPos,chickenNewZPos) * Time.deltaTime;
        }
    }

    void RemoveAfterHit()
    {
        Destroy(gameObject);
    }
}
