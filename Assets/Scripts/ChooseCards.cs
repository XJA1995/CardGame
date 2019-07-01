using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChooseCards : MonoBehaviour
{
    private GameObject Choosecards;
    private GameObject CardsPanel;

    public GameObject prefabs;

    public Boss boss;
    public Feeshow feeshow;
    public GameControll gameControll;
    public CardManage cardManage;
    public Hero hero;

    private Button GoNextBoss;

    private List<Card> CanChooseCards = new List<Card>();//存放用于选择的卡牌

    private bool flag = false;//当flag的值为true时，激活卡牌的单击响应

    public static ChooseCards Instance { get; private set; }

    public bool GetFlag()
    {
        return flag;
    }

    private void Awake()
    {
        Instance = this;
        Choosecards = GameObject.Find("ChooseCards");
        CardsPanel = GameObject.Find("CardsPanel");

        GoNextBoss = GameObject.Find("GoNextBoss").GetComponent<Button>();

        Choosecards.gameObject.SetActive(false);
    }

    private void Start()
    {
        boss = Boss.Instance;
        feeshow = Feeshow.Instance;
        gameControll = GameControll.Instance;
        cardManage = CardManage.Instance;
        hero = Hero.Instance;
    }

    public void GetCanChooseCards()//从牌库中获取8张卡牌供玩家选择
    {
        Choosecards.gameObject.SetActive(true);

        StreamReader sr = new StreamReader(@"e:\Card.csv", Encoding.GetEncoding("utf-8"));
        string[] line = new string[14];
        
        Card card;

        for (int n = 0; n < 14; n++)
        {
            line[n] = sr.ReadLine();
        }

        for (int i = 0; i < 8; i++)
        {
            int j = UnityEngine.Random.Range(0, 14);

            card = new Card(line[j].ToString().Split(' ')[0], line[j].ToString().Split(' ')[1], line[j].ToString().Split(' ')[2], Convert.ToInt32(line[j].ToString().Split(' ')[3]), Convert.ToInt32(line[j].ToString().Split(' ')[4]), line[j].ToString().Split(' ')[5]);
            CanChooseCards.Add(card);


        }
        flag = true;

        foreach (var data in CanChooseCards)//将八张卡牌显示出来
        {
                GameObject Card = GameObject.Instantiate(prefabs, CardsPanel.transform) as GameObject;
                Card.GetComponent<InstanceCard>().SetCard(data);//挂载生成卡牌的基本信息
                Card.GetComponent<InstanceCard>().SetImage(data.CardName1);//设置卡牌的图片
        }
    }

    public void DestroyCard()//选牌结束后，将生成的卡牌删除
    {
        foreach (Transform child in CardsPanel.transform)
        {
            Destroy(child.gameObject);
        }
        CanChooseCards.Clear();
    }

    public void GoNextBossOnClick()//初始化下一个对战场景
    {
        DestroyCard();
        Choosecards.gameObject.SetActive(false);
        flag = false;
        boss.Re_SetBoss();
        hero.Re_SetHero();
        feeshow.SetFee(4);
        cardManage.CopyGroups();
        gameControll.SendCards(4);
    }
    
}
