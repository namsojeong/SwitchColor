using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    [SerializeField]
    ObjectPoolData objectPoolData;
    [SerializeField]
    GameObject objectPool;

    Dictionary<PoolObjectType, Queue<GameObject>> poolObjectMap = new Dictionary<PoolObjectType, Queue<GameObject>>();

    private void Awake()
    {
        Instance = this;

        Initialize();
    }

    private void Initialize()
    {
        for (int i = 0; i < objectPoolData.prefabs.Count; i++)
        {
            poolObjectMap.Add((PoolObjectType)i, new Queue<GameObject>());

                poolObjectMap[(PoolObjectType)i].Enqueue(CreateNewObject(i));
        }
    }

    //������Ʈ ���� �س���
    private GameObject CreateNewObject(int index)
    {
        var newObj = Instantiate(objectPoolData.prefabs[index]);
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }

    //���� (��������)
    public GameObject GetObject(PoolObjectType type)
    {
        if (Instance.poolObjectMap[type].Count > 0)
        {
            var obj = Instance.poolObjectMap[type].Dequeue();
            obj.transform.SetParent(transform);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newObj = Instance.CreateNewObject((int)type);
            newObj.gameObject.SetActive(true);
            newObj.transform.SetParent(transform);

            return newObj;
        }
    }

    //������Ʈ ����
    public void ReturnObject(PoolObjectType type, GameObject obj)
    {
        switch (obj.tag)
        {
            case "Coin":
                if (obj.transform.parent == gameObject.transform)
                    return;
                break;
        }

        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance.poolObjectMap[type].Enqueue(obj);
    }
}