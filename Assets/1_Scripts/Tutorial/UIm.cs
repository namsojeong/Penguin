using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIm : MonoBehaviour
{
    [SerializeField]
    AudioSource clickSource;

    public GameObject botomButton;
    public GameObject App;

    public Image Imgages;

    public GameObject character;

    public GameObject state;
    public List<Sprite> tutoimage;

    int i =0;
    void Start()
    {
        Invoke("ImageOn", 3f);
        Imgages.gameObject.SetActive(false);
    }

    private void ImageOn()
    {
        Debug.Log("d");
       //new WaitForSeconds(3f);
        botomButton.SetActive(false);
        App.SetActive(false);
        character.SetActive(false);
        state.SetActive(false);
        Imgages.gameObject.SetActive(true);
    }

    public void OnClickButton()
    {
        ClickPassSound();
        i++;
        if(i+2 > tutoimage.Count)
        {

        SceneManager.LoadScene("Main");
        }
        Imgages.sprite = tutoimage[i];
    }


    public void ClickPassSound()
    {
        clickSource.Play();
    }
}
