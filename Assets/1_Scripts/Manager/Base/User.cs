using System.Collections.Generic;
using UnityEngine.Networking;
using System;

[System.Serializable]
public class User
{
    // �ɷ�
    public int art = 0;
    public int pe = 0;
    public int study = 0;
    public int charm = 0;

    //�����
    public float hungry = 100;
    public float fun = 100;
    public float clean = 100;
    public float sleep = 100;

    // ����
    public int shrimpCnt = 0;
    public int squidCnt = 0;
    public int fishCnt = 0;

    // ��ȭ
    public int coin = 100;
    public int day = 1;
    public int arbTime = 0;

    public bool isFirst = true;

    public List<Item> items = new List<Item>();
}
