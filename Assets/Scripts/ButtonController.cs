using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour , IUpdateSelectedHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] UnityEvent OnButtonHold;
    bool isHold;

    public void OnPointerDown(PointerEventData data) {
        isHold = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHold = false;
    }

    public void OnUpdateSelected(BaseEventData eventData)
    {
        if (isHold)
        {
            OnButtonHold?.Invoke();
        }
    }
}
