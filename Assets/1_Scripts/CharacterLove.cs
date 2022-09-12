using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLove : MonoBehaviour
{
    //[SerializeField]
    //GameObject penguin;
    [SerializeField]
    GameObject heartEffect;
    [SerializeField]
    AudioClip loveAudio;

    [SerializeField]
    Button loveButton;

    bool isLoving = false;
    private void Awake()
    {
        loveButton.onClick.AddListener(() => Loving());
    }
    private void Update()
    {
        loveButton.transform.position =  Camera.main.WorldToScreenPoint(transform.position);
    }
    private void Loving()
    {
        if (isLoving) return;
        isLoving = true;
        heartEffect.transform.position = transform.position;
        SoundManager.instance.SFXPlay(loveAudio);
        heartEffect.SetActive(true);
        Invoke("HeartEffectOff", 1f);
    }
    void HeartEffectOff()
    {
        isLoving = false;
        heartEffect.SetActive(false);
    }
}
