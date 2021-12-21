using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StandbyScreen : UIScreen
{
    [Header("UI 버튼")]
    [SerializeField]
    Button startButton;
    [SerializeField]
    Button shopButton;

    private void Awake()
    {
        //플레이버튼
        startButton.onClick.AddListener(()=> {
            GameManager.Instance.UpdateState(GameState.RUNNING);
            ObjComponent.Instance.StartRun();
        });

        shopButton.onClick.AddListener(() => GameManager.Instance.UpdateState(GameState.SHOP));
    }
    public override void UpdateScreenStatus(bool open)
    {
        base.UpdateScreenStatus(open);
    }
}
