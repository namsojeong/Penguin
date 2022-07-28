using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtGameManager : MonoBehaviour
{
    [SerializeField]
    GameObject start;
    [SerializeField]
    GameObject main;

    private void Start()
    {
        start.SetActive(true);
        main.SetActive(false);
    }
}
