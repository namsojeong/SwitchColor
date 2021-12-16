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
    //Àü¸é±¤°í
    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Debug.Log("µÅ");
            Advertisement.Show("video");
        }
        else
        {
            Debug.Log("¾ÈµÅ");
        }
    }
}
