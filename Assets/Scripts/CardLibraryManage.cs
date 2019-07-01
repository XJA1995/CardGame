using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardLibraryManage : MonoBehaviour
{
    public CardManage cardManage;
    public GameObject Prefabs;

    private Button CanUseCards;//可用牌堆按钮
    private Button DiscardPile;//弃牌堆按钮
    private Button DisabledCard;//不可用牌堆按钮


    private Button NextPage;
    private Button PrePage;
    private Text PageShow;
    private Text CardGroupName;
    private Button ReturnFight;//返回对战


    private GameObject CardPanel;
    private GameObject CardContext1;
    private GameObject CardContext2;


    List<Card> CardsGroup = new List<Card>();
    List<GameObject> GameObjectGroup = new List<GameObject>();


    private int NowPage = 1;//当前页数
    private int MaxPageNum = 24;//每页最多有24张卡
    private int NowNum = 0;
    public int MaxPages = 2;//最大页数



    private void Awake()
    {
        CanUseCards = GameObject.Find("CanUseCards").GetComponent<Button>();
        DiscardPile = GameObject.Find("DiscardPile").GetComponent<Button>();
        DisabledCard = GameObject.Find("DisabledCard").GetComponent<Button>();

        PrePage = GameObject.Find("PrePage").GetComponent<Button>();
        NextPage = GameObject.Find("NextPage").GetComponent<Button>();
        PageShow = GameObject.Find("PageShow").GetComponent<Text>();
        CardGroupName = GameObject.Find("CardGroupName").GetComponent<Text>();

        ReturnFight = GameObject.Find("ReturnFight").GetComponent<Button>();

        CardPanel = GameObject.Find("CardPanel");
        

        CardContext1 = GameObject.Find("CardContext1");
        CardContext2 = GameObject.Find("CardContext2");


        CardPanel.gameObject.SetActive(false);
    }

    private void Start()
    {
        cardManage = CardManage.Instance;
    }

    public void ReturnFightOnClick()//清空panel中的卡牌
    {
        foreach (var date in GameObjectGroup)
        {
            Destroy(date);
        }
        CardPanel.gameObject.SetActive(false);
    }

    public void CanUseCardsOnClick()//可用牌堆按钮监听事件
    {
        CardsGroup = cardManage.GetList("CardGroups");
        CardPanel.gameObject.SetActive(true);
        


        CardGroupName.text = "可用牌堆";


        foreach (var data in CardsGroup)
        {
            if(NowNum < MaxPageNum)
            {
                GameObject Card = GameObject.Instantiate(Prefabs, CardContext1.transform) as GameObject;
                Card.GetComponent<InstanceCard>().SetCard(data);//挂载生成卡牌的基本信息
                Card.GetComponent<InstanceCard>().SetImage(data.CardName1);//设置卡牌的图片
                GameObjectGroup.Add(Card);
                NowNum += 1;
            }
            else
            {
                GameObject Card = GameObject.Instantiate(Prefabs, CardContext2.transform) as GameObject;
                Card.GetComponent<InstanceCard>().SetCard(data);//挂载生成卡牌的基本信息
                Card.GetComponent<InstanceCard>().SetImage(data.CardName1);//设置卡牌的图片
                GameObjectGroup.Add(Card);
            }
        }
        //CanUseCardsGroup.Clear();
    }

    public void DiscardPileOnClick()//弃牌堆按钮监听事件
    {
        CardsGroup = cardManage.GetList("LostCards");
        CardPanel.gameObject.SetActive(true);



        CardGroupName.text = "弃牌堆";

        foreach (var data in CardsGroup)
        {
            if (NowNum < MaxPageNum)
            {
                GameObject Card = GameObject.Instantiate(Prefabs, CardContext1.transform) as GameObject;
                Card.GetComponent<InstanceCard>().SetCard(data);//挂载生成卡牌的基本信息
                Card.GetComponent<InstanceCard>().SetImage(data.CardName1);//设置卡牌的图片
                GameObjectGroup.Add(Card);
                NowNum += 1;
            }
            else
            {
                GameObject Card = GameObject.Instantiate(Prefabs, CardContext2.transform) as GameObject;
                Card.GetComponent<InstanceCard>().SetCard(data);//挂载生成卡牌的基本信息
                Card.GetComponent<InstanceCard>().SetImage(data.CardName1);//设置卡牌的图片
                GameObjectGroup.Add(Card);
            }
        }
        //DiscardPileGrouo.Clear();
    }

    public void OnClickPre()//上一页
    {
        if (NowPage == 1)
        {
            Debug.Log("没有上一页！！！");
        }
        else
        {
            CardContext2.gameObject.SetActive(false);
            CardContext1.gameObject.SetActive(true);
            NowPage -= 1;
            PageShow.text = NowPage.ToString();
        }
    }

    public void OncClickNext()//下一页
    {
        if (NowPage < MaxPages)//条件：有下一页的情况下执行
        {
            CardContext1.gameObject.SetActive(false);
            CardContext2.gameObject.SetActive(true);
            NowPage += 1;
            PageShow.text = NowPage.ToString();
        }
        else
        {
            Debug.Log("没有下一页了！！！");
        }
    }

}
