using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
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
        moo.PlayOneShot(clip);
        gunshot.PlayOneShot(clip);
        running.PlayOneShot(clip);
        cowbell.PlayOneShot(clip);
        chicken.PlayOneShot(clip);
    }
}
