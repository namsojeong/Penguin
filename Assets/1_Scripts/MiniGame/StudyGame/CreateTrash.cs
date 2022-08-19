using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTrash : MonoBehaviour
{
    public GameObject[] prefabs;
    public ObjectPool poolManager;


    void Start()
    {
        StartCoroutine(SpawnTrash());
    }

    public void Spawn()
    {
        GameObject tr = null;
        int selection = Random.Range(0, prefabs.Length);
        GameObject selectedPrefab = prefabs[selection];

        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0f, 1f), 1.1f, 0));
        pos.z = 0.0f;


        if (poolManager.transform.childCount > 0)
        {
            tr = poolManager.transform.GetChild(0).gameObject;
            tr.transform.SetParent(null);
            tr.SetActive(true);
        }
        else
        {
            tr  =  Instantiate(selectedPrefab, pos, Quaternion.identity);
        }

        tr.transform.SetParent(null);
        tr.transform.position =pos;
    }



    IEnumerator SpawnTrash()
    {
        while(true)
        {
        Spawn();
        yield return new WaitForSeconds(1f);

        }
    }



    void Update()
    {
      
        
    }

   


}
