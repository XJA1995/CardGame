using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UseArea : MonoBehaviour,IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        GameObject card = eventData.pointerDrag;
        if (card == null) return;
        CardListen cardCtrl = card.GetComponent<CardListen>();
        cardCtrl.SetUse(true);
     }

    
}
