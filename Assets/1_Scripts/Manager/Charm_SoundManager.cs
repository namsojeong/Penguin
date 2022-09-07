using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charm_SoundManager : MonoBehaviour
{
    public static SoundManager instance;


    [SerializeField]
    private AudioSource audioBGMSource;
    //[SerializeField]
    //private AudioSource audioSFXSource;
    //[SerializeField]
    //private AudioSource audioClickSource;
    [SerializeField]
    private AudioSource audioPhoneUISource;

    //[SerializeField] AudioClip clickClip;
    //[SerializeField] AudioClip bgmClip;
    //[SerializeField] AudioClip waterClikClip;

    [SerializeField]
    private AudioClip[] sfx;

    private void Awake()
    {
      //  instance = this;
    }


    public void PhoneUISound()
    {
        audioPhoneUISource.Play();
    }

    //// SFX
    //public void SFXPlay(AudioClip clip)
    //{
    //    audioSFXSource.Stop();
    //    audioSFXSource.PlayOneShot(clip);
    //}

    // BGM
    public void BGMStop()
    {
        audioBGMSource.Stop();
    }
    public void BGMStart()
    {
        audioBGMSource.Play();
    }

    //// 터치 시 사운드
    //public void ClikSound()
    //{
    //    audioClickSource.Stop();
    //    audioClickSource.Play();
    //}

    //public void SoundEffect()
    //{
    //    audioSFXSource.Stop();
    //    audioSFXSource.Play();
    //}

}