using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;

    private void Update()
    {
        transform.position+=Vector3.left*moveSpeed*Time.deltaTime;
        Invoke("ReturnObstacle", 5f);
    }

    private void ReturnObstacle()
    {
        PoolManager.instance.ReturnObj(gameObject);
    }
}
