using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("�ΰ��� ���ھ� + ��� Text")]
    [SerializeField]
    Text scoreTxt;
    [SerializeField]
    Text lifeTxt;
    [SerializeField]
    Text bestTxt;

    [Header("���ӿ��� UI Text")]
    [SerializeField]
    Button deadButton;
    [SerializeField]
    GameObject overPanel;
    [SerializeField]
    Text bestOverTxt;
    [SerializeField]
    Text scoreOverTxt;
    
    [Header("����â UI")]
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

    //���� �� ������
    public void ReStart()
    {
        GameManager.Instance.life = 3;
        UpdateUI();
        overPanel.SetActive(false);
        GameManager.Instance.isOver = false;
        InvokeRepeating("Timer", 0f, 1f);
        
    }

    //�׳� �ױ�
    public void Dead()
    {
        overPanel.SetActive(false);
        GameManager.Instance.isOver = false;
        OverUPdateUI();
        GameManager.Instance.UpdateState(GameState.OVER);
        ObjComponent.Instance.ReZero();
        SoundManager.Instance.SoundOn("BGM", 1);
    }

    //�װ� UI ����
    public void OverUI()
    {
        GameManager.Instance.isOver = true;
        overPanel.SetActive(true);
    }

    //�ΰ��� ���ھ� + ������ UI Update
    public void UpdateUI()
    {
        scoreTxt.text = string.Format("SCORE\n{0}", GameManager.Instance.score);
        lifeTxt.text = string.Format("LIFE : {0}", GameManager.Instance.life);
        bestTxt.text = string.Format("BEST SCORE : {0}", GameManager.Instance.bestScore);
    }

    //���ӿ��� UI Update
    public void OverUPdateUI()
    {
        scoreOverTxt.text = string.Format("SCORE\n{0}", GameManager.Instance.score); 
        bestOverTxt.text = string.Format("BEST SCORE\n{0}", GameManager.Instance.bestScore);
    }

    //����â Ű�� ����
    public void Setting()
    {
        isSetting = isSetting ? false : true;
        settingP.SetActive(isSetting);
    }

    //����â Continue ��ư ������ ��
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

    //Continue �� ī��Ʈ�ٿ�
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

    //�⺻ UI ���� Ű��
    public void OpenPanel(GameObject obj)
    {
        obj.SetActive(true);
    }
    public void ClosePanel(GameObject obj)
    {
        obj.SetActive(false);
    }

    //����
    public void Quit()
    {
        Application.Quit();
    }

}
