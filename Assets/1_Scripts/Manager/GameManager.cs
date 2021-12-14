using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState state; //���� ����

    private List<Component> components = new List<Component>();

    private void Awake()
    {
        Screen.SetResolution(2960, 1440, false);

        Instance = this;

        components.Add(new UIComponent());
        UpdateState(GameState.INIT);
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


}
