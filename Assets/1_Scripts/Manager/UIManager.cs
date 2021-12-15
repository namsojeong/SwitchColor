using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField]
    Text scoreTxt;
    [SerializeField]
    Text lifeTxt;
    [SerializeField]
    Text bestTxt;

    [SerializeField]
    Text bestOverTxt;
    [SerializeField]
    Text scoreOverTxt;
    
    [SerializeField]
    Text timeTxt;

    [SerializeField]
    GameObject setting;

    public bool isSetting = false;
    int time=3;

    private void Awake()
    {
        Instance = this;
        if (Instance == null)
            Instance = GetComponent<UIManager>();
    }
    public void UpdateUI()
    {
        scoreTxt.text = string.Format("SCORE\n{0}", GameManager.Instance.score);
        lifeTxt.text = string.Format("LIFE : {0}", GameManager.Instance.life);
        bestTxt.text = string.Format("BEST SCORE : {0}", GameManager.Instance.bestScore);
    }

    public void OverUPdateUI()
    {
        scoreOverTxt.text = string.Format("SCORE\n{0}", GameManager.Instance.score); 
        bestOverTxt.text = string.Format("BEST SCORE\n{0}", GameManager.Instance.bestScore);
    }

    public void Setting()
    {
        isSetting = isSetting ? false : true;
        setting.SetActive(isSetting);
        if(isSetting&&GameManager.Instance.state==GameState.RUNNING)
        {
            InvokeRepeating("Timer", 0f, 1f);
        }
    }

    void Timer()
    {
        time--;
        timeTxt.text = string.Format("{0}", time);
        if(time==0)
        {

            time = 3;
        }
    }

    public void OpenPanel(GameObject obj)
    {
        obj.SetActive(true);
    }
    public void ClosePanel(GameObject obj)
    {
        obj.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
