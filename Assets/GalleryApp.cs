using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryApp : MonoBehaviour
{
    [SerializeField]
    GameObject warning;
    EventParam eventParam = new EventParam();

    public void GoMiniGame(string str)
    {
        SoundManager.instance.ClikSound();
        if(!GameManager.Instance.IsOkayPlay())
        {
            warning.SetActive(true);
            Invoke("CantPlay", 2f);
            return;
        }
        EventManager.TriggerEvent("MiniGame", eventParam);
        bool isCharm = false;
        if(str=="PE")
        {
            GameManager.Instance.UpAbility(AbilityE.PE, 10);
        }
        else if(str=="STUDY")
        {
            GameManager.Instance.UpAbility(AbilityE.STUDY, 10);

        }
        else if(str=="CHARM")
        {
            GameManager.Instance.UpAbility(AbilityE.CHARM, 10);
            isCharm = true;
        }
        else if(str=="JUMP")
        {
            int ranAb = Random.Range(0, 3);
            GameManager.Instance.UpAbility((AbilityE)ranAb, 10);
        }
        if(isCharm)
        SceneM.instance.ChangeScene("CHARMGame_2");
        else
        SceneM.instance.ChangeScene(str+"Game");
    }

    private void CantPlay()
    {
        warning.SetActive(false);
    }
}
