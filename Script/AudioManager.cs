using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource SFXSourceNonLoop;

    public AudioClip backgroundMenu;
    public AudioClip backgroundInGame;
    public AudioClip Death;
    public AudioClip Jump;
    public AudioClip Run;
    public AudioClip Click;
    public AudioClip ReceiveBuff;
    public static AudioManager Instance;
    public bool IsMuted = false;
    

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);   
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }



    void Start()
    {
        MusicMenuPlay();
        MusicSource.Play();
    }

    public void Play()
    {
        if (IsMuted == true)
        { return; }

        MusicSource.Play();
    }
    public void MusicMenuStop()
    {
        MusicSource.Stop();
    }
    public void MusicMenuPlay()
    {
        
        
        MusicSource.clip = backgroundMenu; 
        
       
    }
    public void BackgroundPlay()
    {
        if (IsMuted == true)
        { MusicSource.clip = null;}
        if (IsMuted == false)
        { MusicSource.clip = backgroundInGame; }
    }
    public void PlayRunLoop()
    {
        SFXSource.clip = Run;
        SFXSource.loop = true;
        SFXSource.Play();
    }

    public void StopRunLoop()
    {
        SFXSource.Stop();
        SFXSource.loop = false;
        
    }

    // Update is called once per frame
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
        
    }
    public void PlaySFXNonLoop(AudioClip clip)
    {
        SFXSourceNonLoop.PlayOneShot(clip);

    }




}
