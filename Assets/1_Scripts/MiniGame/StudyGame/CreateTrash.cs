using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTrash : MonoBehaviour
{
    public GameObject[] prefabs;


    void Start()
    {
        StartCoroutine(SpawnTrash());
    }

    public void Spawn()
    {
        int selection = Random.Range(0, prefabs.Length);
        GameObject selectedPrefab = prefabs[selection];

        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0f, 1f), 1.1f, 0));
        pos.z = 0.0f;


        Instantiate(selectedPrefab, pos, Quaternion.identity);

    }



    IEnumerator SpawnTrash()
    {
        while(true)
        {
        Spawn();
        yield return new WaitForSeconds(1f);

        }
    }



   


}
