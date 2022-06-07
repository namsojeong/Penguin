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

    // 재화
    public int coin;
    public bool isSleep;
}

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    string path;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        path = Path.Combine(Application.dataPath + "/Data/", "database.json");
        JsonLoad();
        //안드로이드
        // path = Path.Combine(Application.persistentDataPath, "database.json");
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

            GameManager.instance.coin = 0;
            GameManager.instance.isLamp = true;
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

                GameManager.instance.coin = saveData.coin;
                GameManager.instance.isLamp = saveData.isSleep;
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

        saveData.isSleep = GameManager.instance.isLamp;
        saveData.coin = GameManager.instance.coin;

        string json = JsonUtility.ToJson(saveData, true);

        File.WriteAllText(path, json);
    }

    private void OnApplicationQuit()
    {
        JsonSave();
    }
}
