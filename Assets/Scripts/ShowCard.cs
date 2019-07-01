using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCard : MonoBehaviour
{
    public static ShowCard Instance { get; private set; }
    public Image image;

    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    public void Show(CardListen card)//放大显示鼠标所在的卡牌
    {
        this.gameObject.SetActive(true);
        Image Cardimage = card.Icon;
        image.sprite = Cardimage.sprite;
    }

    public void HiddenCard(CardListen card)
    {
        this.gameObject.SetActive(false);
    }
}
