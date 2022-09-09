using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryApp : MonoBehaviour
{
    EventParam eventParam = new EventParam();

    public void GoMiniGame(string str)
    {
        SoundManager.instance.ClikSound();
        EventManager.TriggerEvent("MiniGame", eventParam);

        if(str=="PE")
        {
            GameManager.instance.UpAbility(AbilityE.PE, 10);
        }
        else if(str=="STUDY")
        {
            GameManager.instance.UpAbility(AbilityE.STUDY, 10);

        }
        else if(str=="CHARM")
        {
            GameManager.instance.UpAbility(AbilityE.CHARM, 10);
        }
        else if(str=="JUMP")
        {
            int ranAb = Random.Range(0, 3);
            Debug.Log((AbilityE)ranAb);
            GameManager.instance.UpAbility((AbilityE)ranAb, 10);
        }
        SceneM.instance.ChangeScene(str+"Game");
    }
}
