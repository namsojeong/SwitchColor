using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Advertise : MonoBehaviour
{
    private void Start()
    {
        string gameId = null;

#if UNITY_ANDROID
        gameId = "4283527";
#elif UNITY_IOS
             gameId = 4283526;
#endif

        if (Advertisement.isSupported && !Advertisement.isInitialized)
        {
            Advertisement.Initialize(gameId);
        }

    }
    //���鱤��
    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("Interstitial_Android");
        }
    }

    //reward����
    public void ShowRewardAd()
    {
        GameManager.Instance.isAd = true;
        if (Advertisement.IsReady())
        {
            ShowOptions options = new ShowOptions { resultCallback = ResultAds };
            Advertisement.Show("Rewarded_Android", options);
        }
        else
        {
            Debug.Log("���� �������� ���߽��ϴ�.");
        }
    }

    void ResultAds(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Failed:
                Debug.Log("���� ���⿡ �����߽��ϴ�.");
                UIManager.Instance.Dead();
                GameManager.Instance.isAd = false;

                break;
            case ShowResult.Skipped:
                Debug.Log("���� ��ŵ�߽��ϴ�.");
                UIManager.Instance.Dead();
                GameManager.Instance.isAd = false;

                break;
            case ShowResult.Finished:
                // ���� ���� ���� ��� 
                UIManager.Instance.ReStart();
                Debug.Log("���� ���⸦ �Ϸ��߽��ϴ�.");
                break;
        }
    }
}
