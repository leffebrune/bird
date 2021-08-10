using UnityEngine;
using System.Collections.Generic;

public class UserData : Singleton<UserData>
{
    const string keyCharacter = "Character";
    const string keyUpgrades = "Upgrades";
    const string keyCoin = "Coin";

    const string defaultCharacter = "Pigeon";

    string currentCharacter = defaultCharacter;
    int coin = 0;
    Dictionary<string, Dictionary<string, int>> Upgrades = new Dictionary<string, Dictionary<string, int>>();

    void _saveUpgrades()
    {
        var json = JSONUtil.SaveKeyValues(Upgrades, (upgrade) => { return JSONUtil.SaveIntDictionary(upgrade); });
        var jsonStr = json.ToString();
        PlayerPrefs.SetString(keyUpgrades, jsonStr);
    }
        
    void _load()
    {
        currentCharacter = PlayerPrefs.GetString(keyCharacter, defaultCharacter);
        coin = PlayerPrefs.GetInt(keyCoin, 0);

        var upgradeStr = PlayerPrefs.GetString(keyUpgrades, "");
        JSONUtil.LoadKeyValues(new JSONObject(upgradeStr), (key, jobj) =>
        {
            if (!Upgrades.ContainsKey(key))
                Upgrades[key] = new Dictionary<string, int>();

            JSONUtil.LoadKeyValues(jobj, (key2, jobj2) =>
            {
                Upgrades[key][key2] = (int)jobj2.i;
            });
        });
    }

    public static string CurrentCharacter
    {
        get { return Instance.currentCharacter; }
        set
        {
            Instance.currentCharacter = value;
            PlayerPrefs.SetString(keyCharacter, Instance.currentCharacter);
        }
    }

    public static int Coin
    {
        get { return Instance.coin; }
        set
        {
            Instance.coin = value;
            PlayerPrefs.SetInt(keyCoin, value);
        }
    }

    public static int GetUpgrade(string character, string key)
    {
        if (!Instance.Upgrades.ContainsKey(character))
            return 0;
        var upgrade = Instance.Upgrades[character];
        if (!upgrade.ContainsKey(key))
            return 0;
        return upgrade[key];
    }

    public static void SetUpgrade(string character, string key, int value)
    {
        if (!Instance.Upgrades.ContainsKey(character))
            Instance.Upgrades[character] = new Dictionary<string, int>();
        Instance.Upgrades[character][key] = value;
        Instance._saveUpgrades();
    }

    public static void Save()
    {
        SetUpgrade("Pigeon", "HP", 0);
        SetUpgrade("Pigeon", "Speed", 1);
        SetUpgrade("Owl", "HP", 0);
        Instance._saveUpgrades();

        PlayerPrefs.Save();
    }

    public static void Load()
    {
        Instance._load();
    }
}

