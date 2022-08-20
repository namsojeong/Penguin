using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{


    public GameObject[] prefabs;

    public GameObject itemPosition;


    void Start()
    {
    }
    void Update()
    {
        
    }


    void RandomItem()
    {
        int selection = Random.Range(0, prefabs.Length);
        GameObject selectedPrefab = prefabs[selection];
        Instantiate(selectedPrefab, itemPosition.transform.position, Quaternion.identity);

    }

    public void OnClickRandomItem()
    {
        RandomItem();
    }
}


