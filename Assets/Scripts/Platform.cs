using UnityEngine;
using System.Collections.Generic;

public class Platform : MonoBehaviour
{
    List<GameObject> pos_birds;
    List<GameObject> pos_mailboxes;
    List<GameObject> pos_coins;

    List<GameObject> attachedObjects = new List<GameObject>();

    void Awake()
    {
        pos_birds = Util.FindAll_StartsWith(gameObject, "pos_bird");
        pos_mailboxes = Util.FindAll_StartsWith(gameObject, "pos_mailbox");
        pos_coins = Util.FindAll_StartsWith(gameObject, "pos_coin");
    }

    void SpawnBirds()
    {
        var h = Environment.Instance.CurrentHour;
        if ((h < 5) || (h > 16))
            return;

        if (Util.Probablity(30.0f))
        {
            foreach (var pos in pos_birds)
            {
                if (Random.Range(0, 100) < 50)
                {
                    var birdObj = ObjectPool.Get("bg_smallbird1", pos);
                    birdObj.transform.localPosition = Vector3.zero;
                    var a = birdObj.MakeComponent<AttachedObject>();
                    a.parent = gameObject;
                    attachedObjects.Add(birdObj);
                }
            }
        }
    }

    void SpawnMailboxes()
    {
        foreach (var pos in pos_mailboxes)
        {
            var obj = ObjectPool.Get("mailbox", pos);
            obj.transform.localPosition = Vector3.zero;
            var a = obj.MakeComponent<AttachedObject>();
            a.parent = gameObject;
            attachedObjects.Add(obj);
        }
    }

    void SpawnCoins()
    {
        foreach (var pos in pos_coins)
        {
            var obj = ObjectPool.Get("item_coin1", pos);
            obj.transform.localPosition = Vector3.zero;
            var a = obj.MakeComponent<AttachedObject>();
            a.parent = gameObject;
            attachedObjects.Add(obj);
        }
    }

    void SpawnItems()
    {
        if (Util.Probablity(30.0f))
        {
            if (Util.Probablity(60.0f))
                SpawnCoins();
            else
                SpawnMailboxes();
        }

    }
    void Initialize()
    {
        attachedObjects.Clear();

        SpawnBirds();
        if (StagePlayer.Instance.LogicPlaying && !StagePlayer.Instance.SegmentPlaying)
            SpawnItems();
    }

    void OnRelease()
    {
        foreach (var obj in attachedObjects)
            ObjectPool.Release(obj);
    }

    void Update()
    {
    }
}
