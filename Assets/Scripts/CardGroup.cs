using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGroup : MonoBehaviour
{
    //public Image image = null;
    //public Sprite sprite;
    public GameObject Cardprefab;
    //public GameObject gameController;
    //public GameObject cardManage;
    //public GameObject Card; 
    //public RectTransform ToCard;

    //private List<GameObject> CardsGroup = new List<GameObject>();
    private List<Card> CardGroups = new List<Card>();


    public static CardGroup Instance { get; private set; }

    //public string[] CardNames;

    private void Awake()
    {
        Instance = this;
    }


    void Update()
    {

    }

    public void CreatMageCardGroup()//初始化法师基础牌组
    {
        Card card;
        for(int i = 0; i < 8; i++)
        {
            if (i < 4)
            {
                //card = new Card("Card001", Professional.mage, CardType.armor, Value.six, Fee.feeone);//四张普通防御牌
                //CardGroups.Add(card);
            }
            else
            {
                //card = new Card("Card002", Professional.mage, CardType.attack, Value.six, Fee.feeone);//四张普通攻击牌
                //CardGroups.Add(card);
            }
            
        }
    }

    public void RandomCreateCard()
    {
        int j = Random.Range(0, CardGroups.Count);
        GameObject Card = GameObject.Instantiate(Cardprefab);
        Card.GetComponent<InstanceCard>().SetCard(CardGroups[j]);
        Card.GetComponent<InstanceCard>().SetImage(CardGroups[j].CardName1);
    }
     
    /*public GameObject RandomGenerateCard()//随机从牌库中抽取一张卡牌（未实现）
    {
        int index = Random.Range(0, 2);
        //gameController = GameObject.Find("GameControll");
        cardManage = GameObject.Find("HandCardManage");
        GameObject go = GameObject.Instantiate(Cardprefab, cardManage.transform) as GameObject;
        RectTransform rect = go.GetComponent<RectTransform>();
        rect.position = ToCard.position;
        sprite = Resources.Load<Sprite>(CardNames[index]);
        image = go.GetComponent<Image>();
        image.sprite = sprite;
        go.GetComponent<CardListen>().index = CardNames[index];
        return go;
    }*/
}
