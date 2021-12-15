using UnityEngine;
using System;
using DG.Tweening;
using System.Collections;

public class FloorComponent : MonoBehaviour
{

    public static FloorComponent Instance;

    Vector3 defaultPos = new Vector3(14.1f, -4.8f, 0f);

    int ranFloor = 1;

    string floorColor = "yellow";

    const string func = "CreateSingleFloor";

    private void Awake()
    {
        Instance = this;
    }

    //RUNNING ����
    public void StartRun()
    {
        InvokeRepeating(func, 0f, 0.7f);
    }

    //�ٴ� �Ѱ� ����
    void CreateSingleFloor()
    {
        GameObject floor = ObjectPool.Instance.GetObject(GetRandomType());
        floor.transform.position = defaultPos;
    }

    //�ٴ� �� ���ϱ�
    protected PoolObjectType GetRandomType()
    {
        ranFloor = UnityEngine.Random.Range(0, 101);
        if (ranFloor >= 70)
        {
            floorColor = "red";
            return PoolObjectType.RedFloor;
        }
        else if (ranFloor >= 40 && ranFloor < 70)
        {
            floorColor = "yellow";
            return PoolObjectType.YellowFloor;

        }
        else if (ranFloor < 40)
        {
            floorColor = "green";
            return PoolObjectType.GreenFloor;
        }
        else
        {
            floorColor = "red";
            return PoolObjectType.RedFloor;
        }

    }

    //���� ���߱�
    public void FloorReset()
    {
        CancelInvoke(func);
    }

}
