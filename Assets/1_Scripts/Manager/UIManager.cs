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
    
}
