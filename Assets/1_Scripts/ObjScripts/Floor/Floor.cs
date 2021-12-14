using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Floor : FloorComponent
{
    [SerializeField]
    PoolObjectType type;

    float speed = 10.69f;
    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < -14f)
        {
            ObjectPool.Instance.ReturnObject(type, gameObject);
        }
    }
}
