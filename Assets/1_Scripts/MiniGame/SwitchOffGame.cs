using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchOffGame : MonoBehaviour
{
    [SerializeField, Header("ON 이미지")]
    Sprite onImage;
    [SerializeField, Header("OFF 이미지")]
    Sprite offImage;
    
    [SerializeField, Header("스위치 이미지")]
    Image[] switchImage;

    [SerializeField, Header("스위치 MAX 개수")]
    int maxSwitch;

    [SerializeField, Header("스위치 꺼지는 시간")]
    float cancelTime = 1f;

    public void StartGame()
    {
        RandomSwitch();
    }

    void RandomSwitch()
    {
        int ran = Random.Range(0, maxSwitch);
        Debug.Log(ran);
        SwitchOn(ran);
    }

    void SwitchOn(int index)
    {
        switchImage[index].sprite = onImage;
        StartCoroutine(Switching(index));
    }


    IEnumerator Switching(int index)
    {
        yield return new WaitForSeconds(cancelTime);
        SwitchOff(index);
    }

    void SwitchOff(int index)
    {
        switchImage[index].sprite = offImage;
        RandomSwitch();
    }

}
