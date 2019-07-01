using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardListen1 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image Icon { get; private set; }
    public Victory victory;

    private void Awake()
    {
        Icon = GetComponent<Image>();
    }

    private void Start()
    {
        victory = Victory.Instance;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //victory.Show(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //victory.HiddenCard(this);
    }
}
