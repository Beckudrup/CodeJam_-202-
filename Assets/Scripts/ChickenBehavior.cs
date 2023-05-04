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
            // the chicken is carried behind the player aka cow, as a
            // child object of the cow,therefor the transform.SetParent(Null)
            // removes it from the hierachy, (so the chicken can go flying.) 
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


    // the method for destroying Chicken object after getting 
    void RemoveAfterHit()
    {
        Destroy(this.gameObject);
    }
}

/// ideas: 1-sound invoke of getting close to chicken, volume getting louder??
/// 2-Need to connect chicken with endgame if hit. 
