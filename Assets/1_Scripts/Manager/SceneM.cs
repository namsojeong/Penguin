using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneM : MonoBehaviour
{
    public static SceneM instance;

    private void Awake()
    {
        instance = this;
    }
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
