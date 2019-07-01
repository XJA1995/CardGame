using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstanceCard : MonoBehaviour
{
    private Image image;//获取图片组件，设置图片
    public Sprite sprite;//获取该卡牌的精灵体
    //public GameObject CardPrefab;//获取卡牌的预制体
    public Card card;//获取卡牌的基本信息

    private void Awake()
    {
        image = this.GetComponent<Image>();
    }
    private void Update()
    {
        
    }
    public void SetCard(Card card)
    {
        this.card = card;
    }

    public Card GetCard()
    {
        return card;
    }

    public void SetImage(string CardName)//通过卡牌名字找到该卡牌的图片（sprite）
    {
        sprite = Resources.Load<Sprite>(CardName);
        image.sprite = sprite;
    }

    /*public GameObject Mageattack() //生成法师的一张普通攻击牌
    {
        cardModel = new CardModel("Card001", Professional.mage, CardType.attack, Value.five, Fee.feeone);//初始化该卡牌的基本信息
        GameObject GoCard = GameObject.Instantiate(CardPrefab);
        image = GoCard.GetComponent<Image>();
        sprite = Resources.Load<Sprite>(cardModel.CardName1);
        image.sprite = sprite;
        return GoCard;
    }

    public GameObject Magearmor() // 生成法师的一张普通护甲牌
    {
        cardModel = new CardModel("Card002", Professional.mage, CardType.armor, Value.five, Fee.feeone);
        GameObject GoCard = GameObject.Instantiate(CardPrefab);
        image = GoCard.GetComponent<Image>();
        sprite = Resources.Load<Sprite>(cardModel.CardName1);
        image.sprite = sprite;
        return GoCard;
    }
    //生成一张卡牌
    public GameObject Instancecard(string cardName, Professional professional, CardType cardType, Value value, Fee fee)
    {
        cardModel = new Card(cardName, Professional.mage, CardType.attack, Value.five, Fee.feeone);
        GameObject GoCard = GameObject.Instantiate(CardPrefab);
        image = GoCard.GetComponent<Image>();
        sprite = Resources.Load<Sprite>(cardModel.CardName1);
        image.sprite = sprite;
        return GoCard;
    }*/
}
