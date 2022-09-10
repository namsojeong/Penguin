using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameAudio : MonoBehaviour
{
    [SerializeField]
    private AudioSource bGM;
    [SerializeField]
    private AudioSource Click;
    [SerializeField]
    private AudioSource fxs;

    private float backVol =1;
    private float fxsVol = 1;

    private void Start()
    {
        Sound();
    }

    private void Sound()
    {
        bGM.volume = PlayerPrefs.GetFloat(ConstantManager.VOL_BACK, backVol);
        Click.volume = PlayerPrefs.GetFloat(ConstantManager.VOL_VFX, fxsVol);
        fxs.volume = PlayerPrefs.GetFloat(ConstantManager.VOL_VFX, fxsVol);

    }
}
