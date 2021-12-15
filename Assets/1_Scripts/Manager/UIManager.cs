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
            settingImg.SetActive(false);
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
