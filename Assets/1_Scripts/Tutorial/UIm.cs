using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIm : MonoBehaviour
{
    [SerializeField]
    AudioSource clickSource;

    public Image Imgages;

    public List<Sprite> tutoimage;

    int i =0;


    public void OnClickButton()
    {
        clickSource.Play();
        i++;
        if(i+2 > tutoimage.Count)
        {
        SceneManager.LoadScene("Main");
        }
        Imgages.sprite = tutoimage[i];
    }


}
