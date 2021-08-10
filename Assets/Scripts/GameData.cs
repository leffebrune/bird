using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GameData : Singleton<GameData>
{
    public class PlayerInfo
    {
        public string Name;
        public string Prefab;
        public float MaxHP;
        public float Agility;
        public Dictionary<string, List<float>> Upgrades = new Dictionary<string, List<float>>();
    }

    Dictionary<string, PlayerInfo> infos = new Dictionary<string, PlayerInfo>();
    public float ScrollSpeed = 3.0f;

    public List<string> Players
    {
        get
        {
            return infos.Keys.ToList();
        }
    }

    void Awake()
    {
        Load();
    }

    void Load()
    {
        var t = Resources.Load<TextAsset>("Data/PlayerInfo");
        JSONUtil.LoadKeyValues(t.text, (key, json) =>
        {
            var _info = new PlayerInfo();
            _info.Name = key;
            _info.Prefab = JSONUtil.GetStringValue(json, "Prefab");
            _info.MaxHP = JSONUtil.GetFloatValue(json, "MaxHP");
            _info.Agility = JSONUtil.GetFloatValue(json, "Agility");
            JSONUtil.LoadDictionary(JSONUtil.GetChild(json, "Upgrades"), ref _info.Upgrades, (jobj) =>
            {
                var output = new List<float>();
                JSONUtil.LoadFloatArray(jobj, ref output);
                return output;
            });

            infos[key] = _info;
        });
    }

    public float GetScrollingSpeed(string layerName)
    {
        return 0.0f;
    }

    public PlayerInfo GetPlayerInfo(string player)
    {
        if (infos.ContainsKey(player))
            return infos[player];
        return null;
    }
}
