using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverScreen : UIScreen
{
    [Header("UI 버튼")]
    [SerializeField]
    Button retryButton;
    [SerializeField]
    Button goStartButton;

    
    private void Awake()
    {

        //다시도전 버튼 터치 시
        retryButton.onClick.AddListener(() => {
            GameManager.Instance.UpdateState(GameState.RUNNING);
            ObjComponent.Instance.StartRun();
        });

        //시작화면가기 버튼 터치 시
        goStartButton.onClick.AddListener(() =>
        {
            SoundManager.Instance.SoundOn("BGM", 0);
            GameManager.Instance.UpdateState(GameState.STANDBY);
        });

    }

    public override void UpdateScreenStatus(bool open)
    {
        base.UpdateScreenStatus(open);
    }
}
