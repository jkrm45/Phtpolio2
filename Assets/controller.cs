using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class controller : MonoBehaviour, IPointerUpHandler, IPointerDownHandler{

    protected bool Pressed;

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }
    // Use this for initialization

}
