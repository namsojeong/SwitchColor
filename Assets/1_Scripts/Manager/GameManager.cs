using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState state; //���� ����

    private List<Component> components = new List<Component>();

    public bool isOver = false;
    public bool isAd = false;

    //User �ΰ��� ����
    public int life = 3;
    public int score = 0;
    public int bestScore = 0;


    private void Awake()
    {

        Screen.SetResolution(2960, 1440, false);

        Instance = this;

        components.Add(new UIComponent());

        UpdateState(GameState.INIT);


    }
    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BESTSCORE", 0);
        SoundManager.Instance.SoundOn("BGM", 0);
        
    }
    //�� �ٲٱ�
    public void UpdateState(GameState state)
    {
        this.state = state;

        for (int i = 0; i < components.Count; i++)
        {
            components[i].UpdateState(state);
        }

        if(state==GameState.INIT)
        {
            UpdateState(GameState.STANDBY);
        }
    }

    //�ν����� â���� �� �ٲٱ�
    public void UpdateSts(string state)
    {
        if(state=="STANDBY")
        {
            SoundManager.Instance.SoundOn("BGM", 0);
            UpdateState(GameState.STANDBY);
        }
        else if(state=="RUNNING")
        {
            ObjComponent.Instance.ReZero();
            ObjComponent.Instance.StartRun();
            UpdateState(GameState.RUNNING);
        }
        else if(state=="OVER")
        {
            SoundManager.Instance.SoundOn("BGM", 1);
            UpdateState(GameState.OVER);
        }
        else if(state=="SHOP")
        {
            UpdateState(GameState.SHOP);

        }
    }

}
