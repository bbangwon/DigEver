using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class sellManDown : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isPressFlag = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressFlag = true;

        // throw new NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //throw new NotImplementedException();
        isPressFlag = false;
    }

}
