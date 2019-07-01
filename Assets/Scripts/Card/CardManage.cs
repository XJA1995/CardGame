using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;



public class CardManage : MonoBehaviour
{

    public GameObject CardPrefab;
    public GameObject cardMannge;

    public RectTransform Card1;//位置信息
    public RectTransform Card2;
    public RectTransform OutCard;

    public static CardManage Instance { get; private set; }

    public Date date;

    public RectTransform rectTransform;

    private float xOffSet;//计算卡牌排列间距
    private List<Card> CardGroups = new List<Card>();//Card卡牌库
    //private List<Card> CardHands = new List<Card>();
    private List<Card> CardLosts = new List<Card>();
    private List<Card> Groups = new List<Card>();//套牌
   

    private List<GameObject> GroupCards = new List<GameObject>();//GameObject卡牌库
    private List<GameObject> HandCards = new List<GameObject>();//手牌库
    private List<GameObject> LostCards = new List<GameObject>();//弃牌库

    private List<GameObject> CardDisposables = new List<GameObject>();//本局对战一次性使用的卡牌

    private int NowCardGroupsNum;

    private int MAXHandCards = 8;



    private void Awake()
    {
        Instance = this;
        CreatCardGroup();//初始化牌库
        //Test();
    }


    void Start()
    {
        xOffSet = Card2.anchoredPosition.x - Card1.anchoredPosition.x;//计算卡牌之间的距离
    }

    void Update()
    {
        
    }

    public List <Card> GetGroups()
    {
        return Groups;
    }

    /*public void Test()
    {
        StreamWriter sw = new StreamWriter(@"e:\Tmp.csv", false);
        for (int i = 0; i < Groups.Count; i++)
        {
            var date = Groups[i];
            var tmp = date.CardName1 + " " + date.Professional + " " + date.CardType + " " + date.Value + " " + date.Fee + " " + date.Play+"\r\n";
            sw.Write(tmp);
        }
        sw.Close();
    }*/

    public List<Card> GetList(string Listname)
    {
        switch (Listname)
        {
            case "CardGroups":
                return CardGroups;
            case "LostCards":
                return CardLosts;
            default:
                Debug.Log("error");
                return null;
        }
    }

    public void CreatCardGroup()//初始化基础牌组（通过文件的读取）通过Date类传过来的HeroName初始化卡组
    {
        //if(Date.Instance.HeroName.Equals ("Hero1"))
        switch (Date.Instance.HeroName)
        {
            case "Hero1":
                {
                    StreamReader sr = new StreamReader(@"e:\Card.csv", Encoding.GetEncoding("utf-8"));
                    string[] line = new string[4];
                    line[0] = sr.ReadLine();
                    line[1] = sr.ReadLine();
                    line[2] = sr.ReadLine();
                    line[3] = sr.ReadLine();
                    Card card;
                    for (int i = 0; i < 8; i++)
                    {
                        if (i < 4)
                        {
                            card = new Card(line[0].ToString().Split(' ')[0], line[0].ToString().Split(' ')[1], line[0].ToString().Split(' ')[2], Convert.ToInt32(line[0].ToString().Split(' ')[3]), Convert.ToInt32(line[0].ToString().Split(' ')[4]), line[0].ToString().Split(' ')[5]);//四张普通防御牌
                            CardGroups.Add(card);
                            Groups.Add(card);
                        }
                        else
                        {
                            card = new Card(line[1].ToString().Split(' ')[0], line[1].ToString().Split(' ')[1], line[1].ToString().Split(' ')[2], Convert.ToInt32(line[1].ToString().Split(' ')[3]), Convert.ToInt32(line[1].ToString().Split(' ')[4]), line[1].ToString().Split(' ')[5]);//四张普通攻击牌
                            CardGroups.Add(card);
                            Groups.Add(card);
                        }
                    }
                    card = new Card(line[2].ToString().Split(' ')[0], line[2].ToString().Split(' ')[1], line[2].ToString().Split(' ')[2], Convert.ToInt32(line[1].ToString().Split(' ')[3]), Convert.ToInt32(line[2].ToString().Split(' ')[4]), line[2].ToString().Split(' ')[5]);
                    Groups.Add(card);
                    CardGroups.Add(card);
                    card = new Card(line[3].ToString().Split(' ')[0], line[3].ToString().Split(' ')[1], line[3].ToString().Split(' ')[2], Convert.ToInt32(line[1].ToString().Split(' ')[3]), Convert.ToInt32(line[3].ToString().Split(' ')[4]), line[3].ToString().Split(' ')[5]);
                    Groups.Add(card);
                    CardGroups.Add(card);
                }
                break;
            case "Hero2":
                Debug.Log("牌还没做");
                {
                    StreamReader sr = new StreamReader(@"e:\Card.csv", Encoding.GetEncoding("utf-8"));
                    string[] line = new string[4];
                    line[0] = sr.ReadLine();
                    line[1] = sr.ReadLine();
                    line[2] = sr.ReadLine();
                    line[3] = sr.ReadLine();
                    Card card;
                    for (int i = 0; i < 8; i++)
                    {
                        if (i < 4)
                        {
                            card = new Card(line[2].ToString().Split(' ')[0], line[2].ToString().Split(' ')[1], line[2].ToString().Split(' ')[2], Convert.ToInt32(line[2].ToString().Split(' ')[3]), Convert.ToInt32(line[2].ToString().Split(' ')[4]), line[2].ToString().Split(' ')[5]);//四张普通防御牌
                            CardGroups.Add(card);
                            Groups.Add(card);
                        }
                        else
                        {
                            card = new Card(line[3].ToString().Split(' ')[0], line[3].ToString().Split(' ')[1], line[3].ToString().Split(' ')[2], Convert.ToInt32(line[3].ToString().Split(' ')[3]), Convert.ToInt32(line[3].ToString().Split(' ')[4]), line[3].ToString().Split(' ')[5]);//四张普通攻击牌
                            CardGroups.Add(card);
                            Groups.Add(card);
                        }
                    }
                    card = new Card(line[0].ToString().Split(' ')[0], line[0].ToString().Split(' ')[1], line[0].ToString().Split(' ')[2], Convert.ToInt32(line[0].ToString().Split(' ')[3]), Convert.ToInt32(line[0].ToString().Split(' ')[4]), line[0].ToString().Split(' ')[5]);
                    Groups.Add(card);
                    CardGroups.Add(card);
                    card = new Card(line[1].ToString().Split(' ')[0], line[1].ToString().Split(' ')[1], line[1].ToString().Split(' ')[2], Convert.ToInt32(line[1].ToString().Split(' ')[3]), Convert.ToInt32(line[1].ToString().Split(' ')[4]), line[1].ToString().Split(' ')[5]);
                    Groups.Add(card);
                    CardGroups.Add(card);
                }
                break;
            case "Hero3":
                Debug.Log("牌还没做too");
                break;
            default:
                Debug.Log("error");
                break;
        }
  
    }

    public void CardGroupsInstance()//可用牌库初始化
    {
        foreach (var date in Groups)
        {
            CardGroups.Add(date);
        }
        Debug.Log(Groups.Count);
    }

    /*public void CreateGroupCards()//将Card->GameObject卡牌库
    {
        for(int i=0;i<CardGroups .Count;i++)
        {
            GameObject Card = GameObject.Instantiate(CardPrefab);
            Card.GetComponent<InstanceCard>().SetCard(CardGroups[i]);
            Card.GetComponent<InstanceCard>().SetImage(CardGroups[i].CardName1);
            GroupCards.Add(Card);
        }
    }*/

    public void RandomCreateCard()//随机从牌库中抽取一张卡放入手牌,返回该卡牌的基本信息
    {
        cardMannge = GameObject.Find("CardManage");
        int j = UnityEngine.Random.Range(0, CardGroups.Count);
        GameObject Card = GameObject.Instantiate(CardPrefab,cardMannge.transform);
        Card.GetComponent<InstanceCard>().SetCard(CardGroups[j]);//挂载生成卡牌的基本信息
        Card.GetComponent<InstanceCard>().SetImage(CardGroups[j].CardName1);//设置卡牌的图片
        Getcard(Card);
        CardGroups.Remove(CardGroups[j]);//牌库减一
        //CardHands.Add(CardGroups[j]);//手牌加一

    }
    public void CardMove()//卡牌的运动
    {
        Vector2 Toposition = Card1.anchoredPosition + new Vector2(xOffSet, 0) * (HandCards.Count - 1);
        RectTransform cardTransform = HandCards[HandCards.Count - 1].GetComponent<RectTransform>();
        cardTransform.anchoredPosition = Vector2.MoveTowards(cardTransform.anchoredPosition, Toposition, 1000f);
    }

    public void UpdateShow()//对手牌进行重新排列位置
    {
        for (int i = 0; i < HandCards.Count; i++)
        {
            Vector2 Toposition = Card1.anchoredPosition + new Vector2(xOffSet, 0) * (i);
            RectTransform cardTransform = HandCards[i].GetComponent<RectTransform>();
            cardTransform.anchoredPosition = Vector2.MoveTowards(cardTransform.anchoredPosition, Toposition, 1000f);
        }
    }
    public void Re_Shuffle()//重新洗牌（当牌库中卡牌数为零时，将弃牌堆中的卡牌加入到牌库中）
    {
        NowCardGroupsNum = CardGroups.Count;
        if (NowCardGroupsNum < 1)
        {
            foreach (var data in CardLosts)
            {
                CardGroups.Add(data);
            }
            CardLosts.Clear();//
        }
    }
    public void Getcard(GameObject cardGo)//获取一张卡牌
    {
        RectTransform Go_rect = cardGo.GetComponent<RectTransform>();
        Go_rect.anchoredPosition  = OutCard.anchoredPosition;
        HandCards.Add(cardGo);
    }
    public void LoseCard(GameObject Go)//使用一张卡牌，从手牌中删除该牌并将其加入到弃牌堆中
    {
        Card card = Go.GetComponent<InstanceCard>().GetCard();//获取该预制体卡牌上挂载的Card类

        //Card类
        //CardHands.Remove(card);//手牌减一
        CardLosts.Add(card);//弃牌堆加一

        //GameObject类
        HandCards.Remove(Go);//手牌减一
        LostCards.Add(Go);//弃牌堆加一

        Destroy(Go);//销毁该预制体
    }

    

    public bool MAXHandCard()//判断手牌数是否超出最大手牌数
    {
        if(HandCards .Count < MAXHandCards)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AddCardGroups(GameObject Go)//向卡组中添加一张牌
    {
        Card card = Go.GetComponent<InstanceCard>().GetCard();

        Groups.Add(card);
        //Debug.Log(Groups.Count);
        Destroy(Go);//销毁该预制体
    }

    public void CopyGroups()//将所有牌堆清空，再把Groups中的Card放入CardGroups中
    {
        CardGroups.Clear();
        CardLosts.Clear();
        foreach (var date in Groups)
        {
            CardGroups.Add(date);
        }
    }

    public void DestroyHandCards()
    {
        int Num = 0;
        foreach (Transform child in cardMannge .transform )  
        {
            if(Num == 0)
            {
                Num += 1;
            }
            else
            {
                Destroy(child.gameObject);
            }
        }
        HandCards.Clear();
        
    }


    IEnumerator Wait(float duration)//等待时间
    {
        for (float timer = 0; timer < duration; timer += Time.deltaTime)
            yield  return 0;
    }

}
