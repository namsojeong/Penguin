using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // 능력
    public int art;
    public int pe;
    public int study;
    public int charm;

    // 영양소
    public float hungry = 100;
    public float fun = 100;
    public float clean = 100;
    public float sleep = 100;

    public int coin;

    public bool isLamp = true;

    private void Awake()
    {
        instance = this;
    }

    public void UpAbility(AbilityE ability, int v)
    {
        switch(ability)
        {
            case AbilityE.ART:
                art += v;
                break;
            case AbilityE.PE:
                pe += v;
                break;
            case AbilityE.STUDY:
                study += v;
                break;
            case AbilityE.CHARM:
                charm += v;
                break;
        }

    }


}
