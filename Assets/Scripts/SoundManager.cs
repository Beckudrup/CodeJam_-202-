using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    /// <summary>
    /// Soundmanager Singleton inspiration from Tarodev 
    /// https://www.youtube.com/watch?v=tEsuLTpz_DU&t=13s&ab_channel=Tarodev
    /// </summary>
    
    [SerializeField] private AudioSource bgm, moo, gunshot, running, cowbell, chicken;
    public static SoundManager Instance;

    

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlaySound(AudioClip clip)
       {
      bgm.PlayOneShot(clip);
         //moo.PlayOneShot(clip);
        // gunshot.PlayOneShot(clip);
        // running.PlayOneShot(clip);
        // cowbell.PlayOneShot(clip);
        // chicken.PlayOneShot(clip);
       }

    /// <summary>
    /// We Should be able to randomize sound effects by taking inspiration from this:
    /// https://www.youtube.com/watch?v=lqyzGntF5Hw&t=12s
    ///(not used yet)
    /// </summary>
    public void Update()
    { // ES- input. part is 'press k do chicken sound, //from here the k sould be moved 
        // to an collider, put script on chicken game object. 
        if (Input.GetKeyDown(KeyCode.K))
        {
                 ChickenSound(chicken.clip);
        }
    }

    // public void BGMSound(AudioClip clip) => bgm.PlayOneShot(clip);
     //public void MooSound(AudioClip clip) => moo.PlayOneShot(clip);
    // public void GunshotSound(AudioClip clip) => gunshot.PlayOneShot(clip);
    // public void RunningSound(AudioClip clip) => running.PlayOneShot(clip);
     public void CowbellSound(AudioClip clip) => cowbell.PlayOneShot(clip);
     public void ChickenSound(AudioClip clip) => chicken.PlayOneShot(clip);
    // public void Gunshot(AudioClip clip) => gunshot.PlayOneShot(clip);

}
