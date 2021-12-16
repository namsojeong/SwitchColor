using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Advertise : MonoBehaviour
{
    const string gameID = "4283527";

    private void Start()
    {
        Advertisement.Initialize(gameID);
    }
    //���鱤��
    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Debug.Log("��");
            Advertisement.Show("video");
        }
        else
        {
            Debug.Log("�ȵ�");
        }
    }
}
