using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIComponent : Component
{
    List<UIScreen> screens = new List<UIScreen>();

    //Scene 추가
    public UIComponent()
    {
        this.screens.Add(GameObject.Find("StandByScreen").GetComponent<UIScreen>());
        this.screens.Add(GameObject.Find("RunningScreen").GetComponent<UIScreen>());
        this.screens.Add(GameObject.Find("OverScreen").GetComponent<UIScreen>());
        this.screens.Add(GameObject.Find("ShopScreen").GetComponent<UIScreen>());
    }

    //씬 Start
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

    //모든 창 닫고 선택 창 열기
    void ActiveScreen(GameState type)
    {
        CloseAllScreens();

        GetScreen(type).UpdateScreenStatus(true);
    }

    //모든 창 닫기
    void CloseAllScreens()
    {
        foreach (var screen in screens)
        {
            screen.UpdateScreenStatus(false);
        }
    }

    //스크린 가져오기
    UIScreen GetScreen(GameState screenState)
    {
        return screens.Find(el => el.screenState == screenState);
    }

}
