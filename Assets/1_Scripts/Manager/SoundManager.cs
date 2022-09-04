using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance; 


    [SerializeField]
    private AudioSource audioBGMSource;
    [SerializeField]
    private AudioSource audioSFXSource;
    [SerializeField]
    private AudioSource audioClickSource;
    [SerializeField]
    private AudioSource audioPhoneUISource;
    
    [SerializeField] AudioClip clickClip;
    [SerializeField] AudioClip bgmClip;
    [SerializeField] AudioClip waterClikClip;
    
    [SerializeField]
    private AudioClip[] sfx;

    private void Awake()
    {
        instance = this;
    }
    


    public void PhoneUISound()
    {
        audioPhoneUISource.Play();
    }

    // SFX
    public void SFXPlay(AudioClip clip)
    {
        audioSFXSource.Stop();
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

    // ��ġ �� ����
    public void ClikSound()
    {
        audioClickSource.Stop();
        audioClickSource.Play();
    }

    public void Soundeffect()
    {
        audioSFXSource.Stop();
        audioSFXSource.Play();
    }


   
}
