using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayArbeit : MonoBehaviour
{
    [SerializeField]
    Image arbBar;

    float maxPlaying = 100;
    float curPlaying = 0;
    float barSpeed = 10;

    EventParam eventParam = new EventParam();

    private void Start()
    {
        EventManager.StartListening("PlayArb", PlayingArb);
    }
    private void OnDestroy()
    {
        EventManager.StopListening("PlayArb", PlayingArb);
    }

    private void Update()
    {
        SliderUpdate();
    }

    void SliderUpdate()
    {
        arbBar.fillAmount = curPlaying / maxPlaying;
    }

    void PlayingArb(EventParam eventParam)
    {
        AbilityE curAr = eventParam.abilityParam;
        Debug.Log(curAr);
        GameManager.instance.coin += 100;
        GameManager.instance.UpAbility(curAr, 10);
        arbBar.fillAmount = 0;
        curPlaying = 0;
        InvokeRepeating("Working", 1f, 1f);
    }

    void Working()
    {
        Debug.Log(curPlaying);
        curPlaying += 10;
        if (curPlaying >= maxPlaying)
        {
            EventManager.TriggerEvent("FinishArb", eventParam);
            CancelInvoke();
        }
    }

}
