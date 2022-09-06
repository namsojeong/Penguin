using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calling : MonoBehaviour
{
    [SerializeField]
     Button noButton;
    [SerializeField]
     Button yesButton;
    [SerializeField]
     Button breakButton;
    
    [SerializeField]
     List<AudioClip> callList;
    [SerializeField]
    AudioSource callClickSource;
    [SerializeField]
    AudioSource callSource;
    [SerializeField]
    GameObject yesPanel;
    [SerializeField]
    GameObject calling;

    [SerializeField]
    private AudioClip callbell;
    [SerializeField]
    private AudioClip callok;
    [SerializeField]
    private AudioClip callno;

    private void Awake()
    {
        noButton.onClick.AddListener(() => NoCall());
        yesButton.onClick.AddListener(() => YesCall());
        breakButton.onClick.AddListener(() => BreakCall());
    }

    private void RandomCalling()
    {
        int ranCall = Random.Range(0, callList.Count);
        callSource.PlayOneShot(callList[ranCall]);
    }

    public void BreakCall()
    {
        yesPanel.SetActive(false);
        calling.SetActive(true);
        ShutDownCalling();
    }

    private void ShutDownCalling()
    {
        CallNO();
        gameObject.SetActive(false);
    }
    
    public void YesCall()
    {
        CallOK();
        yesPanel.SetActive(true);
        calling.SetActive(false);
        RandomCalling();
    }
    
    public void NoCall()
    {
        ShutDownCalling();
        
    }

    // CALLING
    public void CallBell()
    {
        callClickSource.PlayOneShot(callbell);
    }
    public void CallOK()
    {
        callClickSource.PlayOneShot(callok);
    }
    public void CallNO()
    {
        callClickSource.PlayOneShot(callno);
    }

}
