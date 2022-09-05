using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageSaveTime : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        var obj = FindObjectsOfType<MessageTest>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
}
