using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState state; //상태 변수

    private List<Component> components = new List<Component>();

    public int life = 3;
    public int score = 0;
    public int bestScore = 0;


    private void Awake()
    {
        Screen.SetResolution(2960, 1440, false);

        Instance = this;

        components.Add(new UIComponent());
        UpdateState(GameState.INIT);
        bestScore = PlayerPrefs.GetInt("BESTSCORE", 0);
    }

    private void Start()
    {
        
    }

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
    public void UpdateSts(string state)
    {
        if(state=="STANDBY")
        {
            FloorComponent.Instance.FloorReset();
            UpdateState(GameState.STANDBY);
        }
        else if(state=="RUNNING")
        {
            FloorComponent.Instance.StartRun();
            UpdateState(GameState.RUNNING);
        }
        else
        {
            UpdateState(GameState.OVER);
        }
    }

}
