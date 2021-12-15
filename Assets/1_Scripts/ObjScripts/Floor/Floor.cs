using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Floor : MonoBehaviour
{
    [Header("본인 타입")]
    [SerializeField]
    PoolObjectType type;

    float speed = 10.69f;

    private void Update()
    {
        //Floor 이동
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        //게임오버 또는 스탠바이일 때 모든 Floor 리턴
        if(GameManager.Instance.state==GameState.OVER || GameManager.Instance.state == GameState.STANDBY)
        {
            ObjectPool.Instance.ReturnObject(type, gameObject);
        }


        //화면 밖으로 나간 Floor 리턴
        if (transform.position.x < -14f)
        {
            ObjectPool.Instance.ReturnObject(type, gameObject);
        }

    }

}
