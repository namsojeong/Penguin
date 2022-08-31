using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyGameM : MonoBehaviour
{
    public List<GameObject> trash = new List<GameObject>();


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    void RandomTrash()
    {
        float randomtrash = Random.Range(0, trash.Count);

    }
}
