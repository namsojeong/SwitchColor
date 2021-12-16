using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIComponent : Component
{
    List<UIScreen> screens = new List<UIScreen>();

    //Scene �߰�
    public UIComponent()
    {
        this.screens.Add(GameObject.Find("StandByScreen").GetComponent<UIScreen>());
        this.screens.Add(GameObject.Find("RunningScreen").GetComponent<UIScreen>());
        this.screens.Add(GameObject.Find("OverScreen").GetComponent<UIScreen>());
        this.screens.Add(GameObject.Find("ShopScreen").GetComponent<UIScreen>());
    }

    //�� Start
    public void UpdateState(GameState state)
    {
        switch (state)
        {
            case GameState.INIT:
                break;
            default:
                ActiveScreen(state);
                break;
        }
    }

    //��� â �ݰ� ���� â ����
    void ActiveScreen(GameState type)
    {
        CloseAllScreens();

        GetScreen(type).UpdateScreenStatus(true);
    }

    //��� â �ݱ�
    void CloseAllScreens()
    {
        foreach (var screen in screens)
        {
            screen.UpdateScreenStatus(false);
        }
    }

    //��ũ�� ��������
    UIScreen GetScreen(GameState screenState)
    {
        return screens.Find(el => el.screenState == screenState);
    }

}
