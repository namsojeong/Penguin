using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSetManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioBGMSource;
    [SerializeField]
    private AudioSource audioSFXSource;

    [SerializeField]
    private AudioSource audioClickSource;

    private float backVol = 1;
    private float vfxVol = 1;

    public Slider BGMSlider;
    public Slider FXSlider;


    private void Start()
    {
        SetVolume();
    }
    private void SetVolume()
    {
        backVol = PlayerPrefs.GetFloat(ConstantManager.VOL_BACK, 1f);
        BGMSlider.value = backVol;

        vfxVol = PlayerPrefs.GetFloat(ConstantManager.VOL_VFX, 1f);
        FXSlider.value = vfxVol;



    }

    public void BGMSoundSlider()
    {
        audioBGMSource.volume = BGMSlider.value;
        backVol = BGMSlider.value;

        PlayerPrefs.SetFloat(ConstantManager.VOL_BACK, backVol);


    }
    public void FXSoundSlider()
    {
        audioSFXSource.volume = FXSlider.value;
        audioClickSource.volume = FXSlider.value;

        vfxVol = FXSlider.value;
        PlayerPrefs.SetFloat(ConstantManager.VOL_VFX, vfxVol);


    }
}

