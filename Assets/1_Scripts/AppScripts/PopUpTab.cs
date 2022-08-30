using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpTab : MonoBehaviour
{
    [SerializeField]
    GameObject popup;

    [SerializeField]
    Transform defaultPos;
    [SerializeField]
    Transform resultPos;
    void MoveDown()
    {
        popup.SetActive(true);
        popup.transform.position = defaultPos.position;
        //transform.position = Mathf.Lerp(transform.position, resultPos.position, 5f);
    }
}
