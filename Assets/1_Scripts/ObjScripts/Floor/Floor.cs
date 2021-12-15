using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Floor : MonoBehaviour
{
    [Header("���� Ÿ��")]
    [SerializeField]
    PoolObjectType type;

    float speed = 10.69f;

    private void Update()
    {
        //Floor �̵�
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        //���ӿ��� �Ǵ� ���Ĺ����� �� ��� Floor ����
        if(GameManager.Instance.state==GameState.OVER || GameManager.Instance.state == GameState.STANDBY)
        {
            ObjectPool.Instance.ReturnObject(type, gameObject);
        }


        //ȭ�� ������ ���� Floor ����
        if (transform.position.x < -14f)
        {
            ObjectPool.Instance.ReturnObject(type, gameObject);
        }

    }

}
