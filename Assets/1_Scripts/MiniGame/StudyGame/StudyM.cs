using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyM : MonoBehaviour
{
        
    public PoolManager poolManager { get; private set; }
    void Start()
    {
        poolManager = FindObjectOfType<PoolManager>();
    }

    void Update()
    {
        
    }
}
