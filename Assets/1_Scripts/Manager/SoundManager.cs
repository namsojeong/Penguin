using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioBGMSource;
    [SerializeField]
    private AudioSource audioSFXSource;
    [SerializeField]
    private AudioSource audioClickSource;
    [SerializeField]
    private AudioClip callbell;
    [SerializeField]
    private AudioClip callok;
    [SerializeField]
    private AudioClip callno;
    
    [SerializeField]
    private AudioClip clickClip;
    [SerializeField]
    private AudioClip bgmClip;
    
    [SerializeField]
    private AudioClip[] sfx;

    void Start()
    {
       
    }

    void Update()
    {
       
      
    }


    // CALLING
    public void CallBell()
    {
        SFXPlay(callbell);
    }
    public void CallOK()
    {
        SFXPlay(callok);
    }
    public void CallNO()
    {
        SFXPlay(callno);
    }


    // SFX
    public void SFXPlay(AudioClip clip)
    {
        audioSFXSource.PlayOneShot(clip);
    }

    // BGM
    public void BGMStop()
    {
        audioBGMSource.Stop();
    }
    public void BGMStart()
    {
        audioBGMSource.Play();
    }

    // 터치 시 사운드
    public void ClikSound()
    {
        audioClickSource.Play();
    }

}
