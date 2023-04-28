using UnityEngine;

public class ChickenBehavior : MonoBehaviour
{
    bool hitByCow;
    float chickenLifeTime = 8f;

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
            transform.position += new Vector3(0,200,1000) * Time.deltaTime;
        }
    }

    void RemoveAfterHit()
    {
        Destroy(this.gameObject);
    }
}
