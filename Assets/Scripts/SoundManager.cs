using UnityEngine;

public class SoundManager : MonoBehaviour
{
    /// <summary>
    /// Soundmanager Singleton inspiration from Tarodev 
    /// https://www.youtube.com/watch?v=tEsuLTpz_DU&t=13s&ab_channel=Tarodev
    /// </summary>
    
    [SerializeField] AudioSource bgm, moo, gunshot, running, cowbell, chicken, milkshake;
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

    public void BGMSound()
    {
        if (bgm.isPlaying) return;
        bgm.Play();
    }

    public void MooSound() => moo.PlayOneShot(moo.clip);
    public void GunshotSound() => gunshot.PlayOneShot(gunshot.clip);
    public void CowbellSound() => cowbell.PlayOneShot(cowbell.clip);
    public void ChickenSound() => chicken.PlayOneShot(chicken.clip);

    public void MilkshakeSound()
    {
        if (milkshake.isPlaying) return;    
        milkshake.PlayOneShot(milkshake.clip);
    }

    public void RunningSound()
    {
        if (running.isPlaying) return;
        running.PlayOneShot(running.clip);
    }

    public void RunningSoundStop() => running.Stop();


}
