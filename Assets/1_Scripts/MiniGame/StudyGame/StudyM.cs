using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyM : MonoBehaviour
{
        
    public ObjectPool poolManager { get; private set; }
    void Start()
    {
        poolManager = FindObjectOfType<ObjectPool>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
