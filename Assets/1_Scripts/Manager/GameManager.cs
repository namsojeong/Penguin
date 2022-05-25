using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 능력
    int art;
    int pe;
    int study;
    int charm;

    private void Awake()
    {

        // 능력치 데이터 가져오기
        art = PlayerPrefs.GetInt("ART", 0);
        pe = PlayerPrefs.GetInt("PE", 0);
        study = PlayerPrefs.GetInt("STUDY", 0);
        charm = PlayerPrefs.GetInt("CHARM", 0);
    }

    // 능력치 올리기
    public void UpAbility(AbilityE ability, int v)
    {
        switch(ability)
        {
            case AbilityE.ART:
                art += v;
                PlayerPrefs.SetInt("ART", art);
                break;
            case AbilityE.PE:
                pe += v;
                PlayerPrefs.SetInt("PE", pe);
                break;
            case AbilityE.STUDY:
                study += v;
                PlayerPrefs.SetInt("STUDY", study);
                break;
            case AbilityE.CHARM:
                charm += v;
                PlayerPrefs.SetInt("CHARM", charm);
                break;
        }

    }


}
