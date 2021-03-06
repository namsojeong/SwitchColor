using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScreen : MonoBehaviour
{
    [SerializeField]
    internal GameState screenState = GameState.STANDBY;
    [SerializeField]
    protected CanvasGroup canvasGroup;
    [SerializeField]
    protected GameObject screenObj;

    //스크린 상태 (끄고 키기)
    public virtual void UpdateScreenStatus(bool open)
    {
        canvasGroup.alpha = open ? 1 : 0;
        canvasGroup.blocksRaycasts = open;
        canvasGroup.interactable = open;
        screenObj.gameObject.SetActive(open);
    }


}
