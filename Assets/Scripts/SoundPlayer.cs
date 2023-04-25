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
    [SerializeField] private AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlaySound(clip);
    }


}
