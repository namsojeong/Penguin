using System.Collections.Generic;
using UnityEngine.Networking;
using System;

[System.Serializable]
public class User
{
    // 능력
    public int art = 0;
    public int pe = 0;
    public int study = 0;
    public int charm = 0;

    //영양소
    public float hungry = 100;
    public float fun = 100;
    public float clean = 100;
    public float sleep = 100;

    // 먹이
    public int shrimpCnt = 0;
    public int squidCnt = 0;
    public int fishCnt = 0;

    // 재화
    public int coin = 100;
    public int day = 1;
    public int arbTime = 0;
    public int ranPrice = 0;
    public int specialCnt = 0;

    public bool isFirst = true;
    public bool isSpecialAll = false;
    public bool isTryRan = false;

    public int messageTime = 0;
    public bool messaeging = false;

    public List<Item> items = new List<Item>();
    public List<SpecialItem> specialItems = new List<SpecialItem>();
}
