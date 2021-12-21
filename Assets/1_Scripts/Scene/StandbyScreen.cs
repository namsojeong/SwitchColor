using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StandbyScreen : UIScreen
{
    [Header("UI ��ư")]
    [SerializeField]
    Button startButton;
    [SerializeField]
    Button shopButton;

    private void Awake()
    {
        //�÷��̹�ư
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
