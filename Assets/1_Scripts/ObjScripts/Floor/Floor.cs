using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Floor : MonoBehaviour
{
    [SerializeField]
    PoolObjectType type;

    float speed = 10.69f;

    bool isDead = false;
    private void Update()
    {
        if(GameManager.Instance.state==GameState.OVER)
        {
            isDead = true;
            ObjectPool.Instance.ReturnObject(type, gameObject);
        }

        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < -14f)
        {
            isDead = true;
            ObjectPool.Instance.ReturnObject(type, gameObject);
        }

    }

}
