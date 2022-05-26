using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchOffGame : MonoBehaviour
{
    [SerializeField, Header("ON �̹���")]
    Sprite onImage;
    [SerializeField, Header("OFF �̹���")]
    Sprite offImage;
    
    [SerializeField, Header("����ġ �̹���")]
    Image[] switchImage;

    [SerializeField, Header("����ġ MAX ����")]
    int maxSwitch;

    [SerializeField, Header("����ġ ������ �ð�")]
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
