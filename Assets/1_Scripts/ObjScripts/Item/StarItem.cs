using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarItem : MonoBehaviour
{
    [Header("본인 타입")]
    [SerializeField]
    PoolObjectType type;

    private void Update()
    {
        if (GameManager.Instance.state == GameState.OVER || GameManager.Instance.state == GameState.STANDBY)
        {
            ObjectPool.Instance.ReturnObject(type, gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.Instance.SoundOn("SFX", 0);
            ObjectPool.Instance.ReturnObject(type, gameObject);
        }
    }

}
