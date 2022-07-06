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
    Button loveButton;

    bool isLoving = false;
    private void Awake()
    {
        loveButton.onClick.AddListener(() => Loving());
    }
    private void Loving()
    {
        if (isLoving) return;
        Debug.Log("¡¡æ∆!!");
        isLoving = true;
        heartEffect.transform.position = transform.position;
        heartEffect.SetActive(true);
        Invoke("HeartEffectOff", 1f);
    }
    void HeartEffectOff()
    {
        isLoving = false;
        heartEffect.SetActive(false);
    }
}
