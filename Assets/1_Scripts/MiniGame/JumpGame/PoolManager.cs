using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager instance;

    [SerializeField]
    GameObject prefab;
    [SerializeField]
    GameObject keepObject;

    [SerializeField]
    int spawnCnt;

    Coroutine spawnC;
    float spawnSpeed = 4.5f;


    private void Awake()
    {
        instance = this;
    }

    public void SpawnPlay()
    {
        ResetObj(); 
        StartSpawn();
    }

    //시작 자식 스폰
    public void StartSpawn()
    {
        for (int i = 0; i < spawnCnt; i++)
        {
            GameObject obj;
            obj = Instantiate(prefab, new Vector2(4f, 0f), Quaternion.identity);
            obj.transform.SetParent(gameObject.transform, false);
            obj.SetActive(false);
        }
        spawnC = StartCoroutine(PoolSpawn());
    }

    //적 풀링 실행
    public IEnumerator PoolSpawn()
    {
        float randomDelay = 5f;
        while (true)
        {
            randomDelay = Random.Range(2, spawnSpeed);
            if(spawnSpeed>2f)  spawnSpeed -= 0.003f;
            InstanceObj();
            yield return new WaitForSeconds(randomDelay);
        }
    }

    public GameObject InstanceObj()
    {
        GameObject enemy = null;

        if (gameObject.transform.childCount > 0)
        {
            enemy = gameObject.transform.GetChild(0).gameObject;
            enemy.transform.SetParent(keepObject.transform);
        }
        else
        {
            GameObject newEnemy = Instantiate(prefab);
            enemy = newEnemy;
        }
        float ranY = Random.Range(-2f, 2.1f);
        enemy.transform.position = new Vector2(4f, ranY);
        enemy.SetActive(true);
        return enemy;
    }

    public void ReturnObj(GameObject reObj)
    {
        reObj.transform.SetParent(gameObject.transform);
        reObj.SetActive(false);
    }

    public void GameOver()
    {
        StopCoroutine(spawnC);
    }

    public void ResetObj()
    {

        if (gameObject.transform.childCount != 0)
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                GameObject obj = gameObject.transform.GetChild(i).gameObject;
                Destroy(obj);
            }
        }

        if (keepObject.transform.childCount != 0)
        {
            for (int i = 0; i < keepObject.transform.childCount; i++)
            {
                GameObject obj = keepObject.transform.GetChild(i).gameObject;
                Destroy(obj);
            }
        }
    }

}
