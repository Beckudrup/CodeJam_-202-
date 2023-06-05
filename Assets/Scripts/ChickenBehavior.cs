using UnityEngine;

public class ChickenBehavior : MonoBehaviour
{
    bool hitByCow;
    float chickenLifeTime = 8f;
    


    //colides w. Chicken
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

    // direction coords of flying chicken
    float ChickenflyX = 0f;
    float ChickenflyY = 200f;
    float ChickenflyZ = 1000f;

    void Update()
    {
        if (hitByCow)
        {
            transform.position += new Vector3(ChickenflyX, ChickenflyY, ChickenflyZ) * Time.deltaTime;
            
        }
    }

    // the method for destroying Chicken object after chickenLifeTime has ended (8f).
    void RemoveAfterHit()
    {
        Destroy(this.gameObject);

    }
}


