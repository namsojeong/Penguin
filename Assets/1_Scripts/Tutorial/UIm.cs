using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIm : MonoBehaviour
{

    public GameObject botomButton;
    public GameObject App;

    public GameObject Imgages;

    public GameObject character;

    public GameObject state;
    public List<GameObject> Image;
    void Start()
    {
        Invoke("ImageOn", 3f);
        Imgages.SetActive(false);
    }

    void Update()
    {
        
    }


    private void ImageOn()
    {
        Debug.Log("d");
       //new WaitForSeconds(3f);
        botomButton.SetActive(false);
        App.SetActive(false);
        character.SetActive(false);
        state.SetActive(false);
        Imgages.SetActive(true);
    }

    public void OnClickButton()
    {
        for (int i = 0; i > 17; i++)
        {
            Imgages =  Image[i];
            Debug.Log("1");
        }

        SceneManager.LoadScene("Main");
    }

}
