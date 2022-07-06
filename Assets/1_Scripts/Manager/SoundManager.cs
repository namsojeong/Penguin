using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip callbell;
    [SerializeField]
    private AudioClip callok;
    [SerializeField]
    private AudioClip callno;

    void Start()
    {
       
    }

    void Update()
    {
       
      
    }

    public void CallBell()
    {
        audioSource.PlayOneShot(callbell);
    }


    public void CallOK()
    {
        audioSource.PlayOneShot(callok);
    }

    public void CallNO()
    {
        audioSource.PlayOneShot(callno);
    }


}
