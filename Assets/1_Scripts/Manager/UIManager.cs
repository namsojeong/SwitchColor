using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("인게임 스코어 + 목숨 Text")]
    [SerializeField]
    Text scoreTxt;
    [SerializeField]
    Text lifeTxt;
    [SerializeField]
    Text bestTxt;

    [Header("게임오버 UI Text")]
    [SerializeField]
    Text bestOverTxt;
    [SerializeField]
    Text scoreOverTxt;
    
    [Header("설정창 UI")]
    [SerializeField]
    Text timeTxt;
    [SerializeField]
    GameObject settingImg;
    [SerializeField]
    GameObject settingP;

    public bool isSetting = false;
    int time=3;

    private void Awake()
    {
        Instance = this;
        if (Instance == null)
            Instance = GetComponent<UIManager>();
    }

    //인게임 스코어 + 라이프 UI Update
    public void UpdateUI()
    {
        scoreTxt.text = string.Format("SCORE\n{0}", GameManager.Instance.score);
        lifeTxt.text = string.Format("LIFE : {0}", GameManager.Instance.life);
        bestTxt.text = string.Format("BEST SCORE : {0}", GameManager.Instance.bestScore);
    }

    //게임오버 UI Update
    public void OverUPdateUI()
    {
        scoreOverTxt.text = string.Format("SCORE\n{0}", GameManager.Instance.score); 
        bestOverTxt.text = string.Format("BEST SCORE\n{0}", GameManager.Instance.bestScore);
    }

    //설정창 키고 끄기
    public void Setting()
    {
        isSetting = isSetting ? false : true;
        settingP.SetActive(isSetting);
    }

    //설정창 Continue 버튼 눌렀을 때
    public void Continue()
    {
        if (GameManager.Instance.state == GameState.RUNNING)
        {
            settingImg.SetActive(false);
            InvokeRepeating("Timer", 0f, 1f);
        }
        else
        {
            Setting();
        }
    }

    //Continue 후 카운트다운
    void Timer()
    {
        timeTxt.text = string.Format("{0}", time);
        time--;
        if(time<0)
        {
            isSetting = false;
            time = 3;
            settingImg.SetActive(true);
            settingP.SetActive(false);
        }
    }

    //기본 UI 끄고 키기
    public void OpenPanel(GameObject obj)
    {
        obj.SetActive(true);
    }
    public void ClosePanel(GameObject obj)
    {
        obj.SetActive(false);
    }

    //종료
    public void Quit()
    {
        Application.Quit();
    }

}
