using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charm_SoundManager : MonoBehaviour
{
    public static SoundManager instance;


    [SerializeField]
    private AudioSource audioBGMSource;
    [SerializeField]
    private AudioSource audioPhoneUISource;

    [SerializeField]
    private AudioClip[] sfx;

    public void PhoneUISound()
    {
        audioPhoneUISource.Play();
    }
    public void BGMStop()
    {
        audioBGMSource.Stop();
    }
    public void BGMStart()
    {
        audioBGMSource.Play();
    }

}