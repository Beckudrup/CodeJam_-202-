using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    /// <summary>
    /// Soundmanager Singleton inspiration from Tarodev 
    /// https://www.youtube.com/watch?v=tEsuLTpz_DU&t=13s&ab_channel=Tarodev
    /// </summary>
    /// 
    // ES- Audioclip is an array/list so when you call it's name clip you call everything
    // in the list. 
    [SerializeField] private AudioClip clip;
    
    
    void Start()
    {
        SoundManager.Instance.PlaySound(clip);
    }


}
