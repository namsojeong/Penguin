using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Singleton
    private static SoundManager _instance = null;

    public static SoundManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SoundManager>();
                if (_instance == null)
                {
                    _instance = new GameObject("SoundManager").AddComponent<SoundManager>();
                }
            }
            return _instance;
        }
    }
    #endregion

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

    // 터치 시 사운드
    public void ClikSound()
    {
        audioClickSource.Stop();
        audioClickSource.Play();
    }

    public void SoundEffect()
    {
        audioSFXSource.Stop();
        audioSFXSource.Play();
    }

}