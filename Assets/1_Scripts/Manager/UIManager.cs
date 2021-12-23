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
    Button deadButton;
    [SerializeField]
    GameObject overPanel;
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

        deadButton.onClick.AddListener(() =>
        {
            Dead();
        });
    }

    //광고 후 보상목숨
    public void ReStart()
    {
        GameManager.Instance.life = 3;
        UpdateUI();
        overPanel.SetActive(false);
        GameManager.Instance.isOver = false;
        InvokeRepeating("Timer", 0f, 1f);
        
    }

    //그냥 죽기
    public void Dead()
    {
        overPanel.SetActive(false);
        GameManager.Instance.isOver = false;
        OverUPdateUI();
        GameManager.Instance.UpdateState(GameState.OVER);
        ObjComponent.Instance.ReZero();
        SoundManager.Instance.SoundOn("BGM", 1);
    }

    //죽고 UI 띄우기
    public void OverUI()
    {
        GameManager.Instance.isOver = true;
        overPanel.SetActive(true);
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
            settingP.SetActive(true);
            settingImg.SetActive(false);
        timeTxt.text = string.Format("{0}", time);
        time--;
        if(time<0)
        {
            isSetting = false;
            time = 3;
            settingImg.SetActive(true);
            settingP.SetActive(false);
            GameManager.Instance.isAd = false;
            CancelInvoke("Timer");
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
