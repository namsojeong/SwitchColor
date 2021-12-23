using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjComponent : MonoBehaviour
{
    public static ObjComponent Instance;
    private void Awake()
    {
        Instance = this;
    }

    Vector3 defaultPos = new Vector3(14.1f, -4.8f, 0f);

    int ranFloor = 1;
    int ranItem = 1;

    string floorColor = "yellow";


    //RUNNING ����
    public void StartRun()
    {
        GameManager.Instance.score = 0;
        InvokeRepeating("CreateSingleFloor", 0f, 0.7f);
        InvokeRepeating("CreateSingleItem", 0f, 5f);
    }

    //�ٴ� �Ѱ� ����
    void CreateSingleFloor()
    {
        GameObject floor = ObjectPool.Instance.GetObject(GetRandomTypeFloor());
        floor.transform.position = defaultPos;
    }
    
    void CreateSingleItem()
    {
        if (UIManager.Instance.isSetting) return;
        if (GameManager.Instance.isAd) return;
        if (GameManager.Instance.isOver) return;
        Vector2 ranPos = new Vector2(Random.Range(-10, 10), Random.Range(-4, 4));
        GameObject item = ObjectPool.Instance.GetObject(GetRandomTypeItem());
        item.transform.position = ranPos;
    }

    //�ٴ� �� ���ϱ�
    private PoolObjectType GetRandomTypeFloor()
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

    private PoolObjectType GetRandomTypeItem()
    {
        ranItem = UnityEngine.Random.Range(0, 101);
        if (ranItem >= 50)
        {
            return PoolObjectType.StarItem;
        }
        else
        {
            return PoolObjectType.HeartItem;
        }

    }

    //���� ���߱�
    private void FloorReset()
    {
        CancelInvoke("CreateSingleFloor");
    }
    private void ItemReset()
    {
        CancelInvoke("CreateSingleItem");

    }

    public void ReZero()
    {
        FloorReset();
        ItemReset();
    }
}
