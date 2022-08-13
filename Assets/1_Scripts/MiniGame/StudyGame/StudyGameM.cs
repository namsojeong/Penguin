using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyGameM : MonoBehaviour
{
    public static StudyGameM Instance;
    public GameObject[] prefabs;

    public GameObject ballPosition;

    public void Spawn()
    {
        int selection = Random.Range(0, prefabs.Length);
        GameObject selectedPrefab = prefabs[selection];

        Instantiate<GameObject>(selectedPrefab, ballPosition.transform.position, Quaternion.identity);


        if(Input.GetMouseButton(0))
        {
            Destroy(selectedPrefab);
        }
    }
        
    void Start()
    {
        Instance = this;


        Spawn();

    }

    void Update()
    {

    }

}
