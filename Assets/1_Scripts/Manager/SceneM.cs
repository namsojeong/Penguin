using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneM : MonoBehaviour
{

    public void ChangeScene(string scene)
    {
        DataManager.instance.JsonSave();
        SceneManager.LoadScene(scene);
    }
}
