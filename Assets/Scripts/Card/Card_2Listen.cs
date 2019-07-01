using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card_2Listen : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image Icon { get; private set; }
    public MainPanel mainPanel;

    private void Awake()
    {
        Icon = GetComponent<Image>();
    }

    private void Start()
    {
        mainPanel = MainPanel.Instance;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mainPanel.Show(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mainPanel.HiddenCard(this);
    }

}
