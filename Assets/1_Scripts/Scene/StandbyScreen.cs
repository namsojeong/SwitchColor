using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StandbyScreen : UIScreen
{
    [Header("UI ��ư")]
    [SerializeField]
    Button startButton;

    private void Awake()
    {
        //�÷��̹�ư
        startButton.onClick.AddListener(()=> {
            GameManager.Instance.UpdateState(GameState.RUNNING);
            FloorComponent.Instance.StartRun();
        });

    }
    public override void UpdateScreenStatus(bool open)
    {
        base.UpdateScreenStatus(open);
    }
}
