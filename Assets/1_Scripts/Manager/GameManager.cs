using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    int maxEnding;

    [SerializeField]
    private User user = null;
    public User CurrentUser { get { return user; } }
    public Item item = null;
    public SpecialItem specialItem = null;

    private string SAVE_PATH = "";
    private readonly string SAVE_FILENAME = "/SaveFile.txt";

    int lastDay = 25;
    EventParam eventParam = new EventParam();

    private void Awake()
    {
        //해상도
        {
            Time.timeScale = 1;
            Screen.SetResolution(1440, 2560, true);
            instance = this;

            //저장
            SAVE_PATH = Application.persistentDataPath + "/Save";
            if (!Directory.Exists(SAVE_PATH))
            {
                Directory.CreateDirectory(SAVE_PATH);
            }
            LoadFromJson();
            InvokeRepeating("SaveToJson", 1f, 60f);
        }

        if (CurrentUser.isFirst)
        {
            CurrentUser.isFirst = false;
            ResetVal();
        }
        DontDestroyOnLoad(gameObject);
    }

    //저장
    private void LoadFromJson()
    {
        string json = "";
        if (File.Exists(SAVE_PATH + SAVE_FILENAME))
        {
            json = File.ReadAllText(SAVE_PATH + SAVE_FILENAME);
            user = JsonUtility.FromJson<User>(json);
        }
        else
        {
            SaveToJson();
            LoadFromJson();
        }
    }
    public void SaveToJson()
    {
        SAVE_PATH = Application.persistentDataPath + "/Save";
        if (user == null) return;
        string json = JsonUtility.ToJson(user, true);
        File.WriteAllText(SAVE_PATH + SAVE_FILENAME, json, System.Text.Encoding.UTF8);
        PlayerPrefs.SetString("SaveLastTime", System.DateTime.Now.ToString());

    }

    //종료 시 저장
    private void OnApplicationQuit()
    {
        SaveToJson();
    }
    private void OnApplicationFocus(bool focus)
    {
        SaveToJson();
    }

    public void UpAbility(AbilityE ability, int v)
    {
        switch(ability)
        {
            case AbilityE.PE:
                CurrentUser.pe += v;
                break;
            case AbilityE.STUDY:
                CurrentUser.study += v;
                break;
            case AbilityE.CHARM:
                CurrentUser.charm += v;
                break;
        }

    }

    public void UpNutrient(NutrientE nut, float v)
    {
        switch (nut)
        {
            case NutrientE.HUNGRY:
                CurrentUser.hungry += v;
                if (CurrentUser.hungry <= 0)
                {
                    Debug.Log("배고파서 죽음");
                    Dead();
                }
                else if (CurrentUser.hungry > 100) CurrentUser.hungry = 100;
                    break;
            case NutrientE.CLEAN:
                CurrentUser.clean += v;
                if (CurrentUser.clean <= 0)
                {
                    Debug.Log("더러워서 죽음");
                    Dead();
                }
                else if (CurrentUser.clean > 100) CurrentUser.clean = 100;
                break;
            case NutrientE.FUN:
                CurrentUser.fun += v;
                if (CurrentUser.fun <= 0)
                {
                    Debug.Log("노잼이라 죽음");
                    Dead();
                }
                else if (CurrentUser.fun > 100) CurrentUser.fun = 100;
                break;
            case NutrientE.SLEEP:
                CurrentUser.sleep += v;
                if (CurrentUser.sleep < 0)
                {
                    NextDay();
                }
                break;
        }
    }
    public void NextDay()
    {
        EventManager.TriggerEvent("NextDay", eventParam);
        CurrentUser.day++;
        CurrentUser.sleep = 100;
        if(CurrentUser.day >lastDay)
        {
            EndingSelect();
        }
    }

    private void Dead()
    {
        EndingSelect();
    }

    private void EndingSelect()
    {
        // 수치 계산
        AbilityE ab;
        if (CurrentUser.pe > CurrentUser.study)
        {
            if (CurrentUser.pe > CurrentUser.charm) ab = AbilityE.PE;
            else ab = AbilityE.CHARM;
        }
        else
        {
            if (CurrentUser.study > CurrentUser.charm) ab = AbilityE.STUDY;
            else ab = AbilityE.CHARM;
        }

        if (ab == AbilityE.CHARM)
        {
            if(CurrentUser.charm < maxEnding)  ab = AbilityE.NONE;
        }
        else if(ab == AbilityE.PE)
        {
            if(CurrentUser.pe < maxEnding) ab = AbilityE.NONE;
        }
        else if(ab == AbilityE.STUDY)
        {
            if(CurrentUser.study < maxEnding) ab = AbilityE.NONE;
        }
        GoEnding(ab);
    }
    private void GoEnding(AbilityE ability)
    {
        ResetVal();
        eventParam.abilityParam = ability;
        EventManager.TriggerEvent("GoEnding", eventParam);
    }

    public void ResetVal()
    {
        CurrentUser.hungry = 100;
        CurrentUser.fun = 100;
        CurrentUser.clean = 100;
        CurrentUser.sleep = 100;

        CurrentUser.art = 0;
        CurrentUser.pe = 0;
        CurrentUser.study = 0;
        CurrentUser.charm = 0;

        CurrentUser.shrimpCnt = 1;
        CurrentUser.squidCnt = 0;
        CurrentUser.fishCnt = 0;

        CurrentUser.coin = 100;
        CurrentUser.day = 1;

        CurrentUser.isSpecialAll = false;
        CurrentUser.isTryRan = false;
        CurrentUser.ranPrice = 5000;

        // 아이템 리셋 
        {
            CurrentUser.items.Clear();
            Item currentRibbonItem = new Item();
            currentRibbonItem.name = "앙증맞은 리본";
            currentRibbonItem.index = 0;
            currentRibbonItem.price = 1000;
            currentRibbonItem.isHave = false;
            currentRibbonItem.isGet = false;
            CurrentUser.items.Add(currentRibbonItem);
            Item currentGlassItem = new Item();
            currentGlassItem.name = "어때 나 좀 지적인가?";
            currentGlassItem.index = 1;
            currentGlassItem.price = 1000;
            currentGlassItem.isHave = false;
            currentGlassItem.isGet = false;
            CurrentUser.items.Add(currentGlassItem);
            Item currentBeremoItem = new Item();
            currentBeremoItem.name = "예술가의 상징";
            currentBeremoItem.index = 2;
            currentBeremoItem.price = 1000;
            currentBeremoItem.isHave = false;
            currentBeremoItem.isGet = false;
            CurrentUser.items.Add(currentBeremoItem);
        }

        // 스페셜아이템 리셋 
        {
            CurrentUser.specialItems.Clear();
            SpecialItem specialDress = new SpecialItem();
            specialDress.name = "천사세트";
            specialDress.index = 0;
            specialDress.isHave = false;
            specialDress.isGet = false;
            CurrentUser.specialItems.Add(specialDress);
            
            SpecialItem babyItem = new SpecialItem();
            babyItem.name = "응애 나 애기펭찌";
            babyItem.index = 0;
            babyItem.isHave = false;
            babyItem.isGet = false;
            CurrentUser.specialItems.Add(babyItem);
            
            SpecialItem catItem = new SpecialItem();
            catItem.name = "야옹이세트";
            catItem.index = 0;
            catItem.isHave = false;
            catItem.isGet = false;
            CurrentUser.specialItems.Add(catItem);
            
        }

    }

    public void SetArbTime(int t)
    {
        CurrentUser.arbTime = t;
    }

    public void SetSpriteArb(List<AbilityE> arbs)
    {
        //arbSprites = arbs;
    }

    public void PlusCoin(int pCoin)
    {
        CurrentUser.coin += pCoin;
    }

    public void PlusItemCount(FoodE food, int cnt)
    {
        if (food == FoodE.FISH)
        {
            CurrentUser.fishCnt += cnt;
        }
        else if(food == FoodE.SHRIMP)
        {
            CurrentUser.shrimpCnt += cnt;
        }
        else if(food == FoodE.SQUID)
        {
            CurrentUser.squidCnt += cnt;
        }
    }
}
