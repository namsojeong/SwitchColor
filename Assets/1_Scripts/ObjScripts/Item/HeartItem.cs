using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartItem : MonoBehaviour
{
    [Header("본인 타입")]
    [SerializeField]
    PoolObjectType type;

    private void Update()
    {
        if (GameManager.Instance.state == GameState.OVER || GameManager.Instance.state == GameState.STANDBY)
        {
            GameManager.Instance.itemCount = 0;
            ObjectPool.Instance.ReturnObject(type, gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            GameManager.Instance.itemCount--;
            SoundManager.Instance.SoundOn("SFX", 0);
            ObjectPool.Instance.ReturnObject(type, gameObject);
        }
    }
}
