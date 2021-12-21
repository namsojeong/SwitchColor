using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverScreen : UIScreen
{
    [Header("UI ��ư")]
    [SerializeField]
    Button retryButton;
    [SerializeField]
    Button goStartButton;

    
    private void Awake()
    {

        //�ٽõ��� ��ư ��ġ ��
        retryButton.onClick.AddListener(() => {
            GameManager.Instance.UpdateState(GameState.RUNNING);
            ObjComponent.Instance.StartRun();
        });

        //����ȭ�鰡�� ��ư ��ġ ��
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
