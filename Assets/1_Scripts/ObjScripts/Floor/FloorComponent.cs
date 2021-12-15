using UnityEngine;
using System;
using DG.Tweening;
using System.Collections;

public class FloorComponent : MonoBehaviour
{

    public static FloorComponent Instance;

    Vector3 defaultPos = new Vector3(14.1f, -4.8f, 0f);

    int ranFloor = 1;
    protected string lastran = "red";

    string floorColor = "yellow";

    const string func = "CreateSingleFloor";

    private void Awake()
    {
        Instance = this;
    }

    public void StartRun()
    {
        Debug.Log("시작");
        InvokeRepeating(func, 0f, 0.7f);
    }


    //바닥 한개 생성
    void CreateSingleFloor()
    {
        GameObject floor = ObjectPool.Instance.GetObject(GetRandomType());
        floor.transform.position = defaultPos;
    }

    //바닥 색 타입 정하기
    protected PoolObjectType GetRandomType()
    {
            ranFloor = UnityEngine.Random.Range(0, 101);
        lastran = floorColor;
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

    public void FloorReset()
    {
        Debug.Log("D");
        CancelInvoke(func);
    }

}
