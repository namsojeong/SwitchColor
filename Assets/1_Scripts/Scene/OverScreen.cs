using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverScreen : UIScreen
{
    [SerializeField]
    Button retryButton;
    [SerializeField]
    Button goStartButton;

    
    private void Awake()
    {
        retryButton.onClick.AddListener(() => {
            GameManager.Instance.UpdateState(GameState.RUNNING);
            FloorComponent.Instance.StartRun();
        });
        goStartButton.onClick.AddListener(() =>
        {
            GameManager.Instance.UpdateState(GameState.STANDBY);
        });
    }

    public override void UpdateScreenStatus(bool open)
    {
        base.UpdateScreenStatus(open);
    }
}
