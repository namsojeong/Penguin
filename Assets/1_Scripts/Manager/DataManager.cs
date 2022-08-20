using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveData
{
    // 능력
    public int art;
    public int pe;
    public int study;
    public int charm;

    //영양소
    public float hungry;
    public float fun;
    public float clean;
    public float sleep;
    
    //먹이
    public int shrimp;
    public int squid;
    public int fish;

    // 재화
    public int coin;
    public int day;
    public int arbTime = 0;

    public List<AbilityE> arbs;
}

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    string path;

    void Awake()
    {
        Screen.SetResolution(1440, 2560, true);
        instance = this;
    }

    void Start()
    {
        //path = Path.Combine(Application.dataPath + "/Data/", "database.json");
        //안드로이드
        path = Path.Combine(Application.persistentDataPath, "database.json");
        JsonLoad();
    }

    public void JsonLoad()
    {
        SaveData saveData = new SaveData();

        if (!File.Exists(path))
        {
            GameManager.instance.art = 0;
            GameManager.instance.pe = 0;
            GameManager.instance.study = 0;
            GameManager.instance.charm = 0;

            GameManager.instance.hungry = 100;
            GameManager.instance.fun = 100;
            GameManager.instance.clean = 100;
            GameManager.instance.sleep = 100;

            GameManager.instance.shrimpCount = 0;
            GameManager.instance.squidCount = 0;
            GameManager.instance.fishCount = 0;


            GameManager.instance.arbTime = 0;
            GameManager.instance.arbSprites.Clear();

            GameManager.instance.coin = 100;
            GameManager.instance.day = 1;
            JsonSave();
        }
        else
        {
            string loadJson = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);

            if (saveData != null)
            {
                GameManager.instance.art = saveData.art;
                GameManager.instance.pe = saveData.pe;
                GameManager.instance.study = saveData.study;
                GameManager.instance.charm = saveData.charm;

                GameManager.instance.hungry = saveData.hungry;
                GameManager.instance.fun = saveData.fun;
                GameManager.instance.clean = saveData.clean;
                GameManager.instance.sleep = saveData.sleep;

                GameManager.instance.shrimpCount = saveData.shrimp;
                GameManager.instance.squidCount = saveData.squid;
                GameManager.instance.fishCount = saveData.fish;

                GameManager.instance.arbTime = saveData.arbTime;
                GameManager.instance.arbSprites = saveData.arbs;

                GameManager.instance.coin = saveData.coin;
                GameManager.instance.day = saveData.day;
            }
        }
    }
    public void JsonSave()
    {
        SaveData saveData = new SaveData();

        saveData.art = GameManager.instance.art;
        saveData.pe = GameManager.instance.pe;
        saveData.study = GameManager.instance.study;
        saveData.charm = GameManager.instance.charm;

        saveData.hungry = GameManager.instance.hungry;
        saveData.fun = GameManager.instance.fun;
        saveData.clean = GameManager.instance.clean;
        saveData.sleep = GameManager.instance.sleep;

       saveData.shrimp = GameManager.instance.shrimpCount;
        saveData.squid = GameManager.instance.squidCount;
        saveData.fish = GameManager.instance.fishCount;

        saveData.coin = GameManager.instance.coin;
        saveData.day = GameManager.instance.day;

        saveData.arbTime = GameManager.instance.arbTime;
        saveData.arbs = GameManager.instance.arbSprites;

        string json = JsonUtility.ToJson(saveData, true);

        File.WriteAllText(path, json);
    }

    private void OnApplicationQuit()
    {
        JsonSave();
    }
}
