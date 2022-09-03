using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoEnding : MonoBehaviour
{
    [SerializeField]
    Text dayText;
    [SerializeField]
    GameObject endPanel;
    [SerializeField]
    AudioClip paperSound;

    AbilityE ab;

    EventParam eventParam = new EventParam();

    private void Start()
    {
        EventManager.StartListening("GoEnding", ReadyEnding);
    }
    private void OnDestroy()
    {
        EventManager.StopListening("GoEnding", ReadyEnding);
    }

    void ReadyEnding(EventParam eventParam)
    {
        ab = eventParam.abilityParam;
        dayText.text = string.Format($"25 day");
        endPanel.SetActive(true);

        Invoke("NextDay", 1f);
    }

    void NextDay()
    {
        SoundManager.instance.SFXPlay(paperSound);
        dayText.text = string.Format($"26 day");

        Invoke("GoEnd", 2f);
    }

    void GoEnd()
    {
        SceneM.instance.ChangeScene("End" + ab);
    }
}
