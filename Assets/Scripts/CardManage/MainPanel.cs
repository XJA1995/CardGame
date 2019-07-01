using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.IO;
using System.Text;
using System;

public class MainPanel : MonoBehaviour
{
    private List<GameObject> CardLibrarys = new List<GameObject>();//存储所有卡牌
    private List<Card> LibraryCards = new List<Card>();

    public GameObject Cardprefab;
    private GameObject Showcard;
    private GameObject CardContext1;
    private GameObject CardContext2;

    private Button Return;
    private Button PrePage;
    private Button NextPage;
    private Image image;
    private Text Page;

    private int NowPage = 1;//当前页数
    private int MaxPageNum = 24;//每页最多有24张卡
    public int MaxPages = 2;//最大页数
    private int NowNum = 0;

    public static MainPanel Instance { get; private set; }//单例

   

    private void Awake()
    {
        Instance = this;
        Return = GameObject.Find("ReturnMain").GetComponent<Button>();
        PrePage = GameObject.Find("PrePage").GetComponent<Button>();
        NextPage = GameObject.Find("NextPage").GetComponent<Button>();

        Page = GameObject.Find("PageShow").GetComponent<Text>();

        Showcard = GameObject.Find("Showcard");
        Showcard.gameObject.SetActive(false);
        image = Showcard.GetComponent<Image>();

        CardContext1 = GameObject.Find("CardContext1");
        CardContext2 = GameObject.Find("CardContext2");
        CardContext2.gameObject.SetActive(false);

        Get_Show_AllCard();
    }

    public void OnClickReturn()//返回主菜单
    {
        foreach (var date in CardLibrarys)
        {
            Destroy(date);
        }
        SceneManager.LoadScene("StartGame");
    }

    public void OnClickPre()//上一页
    {
        if(NowPage == 1)
        {
            Debug.Log("没有上一页！！！");
        }
        else
        {
            CardContext2.gameObject.SetActive(false);
            CardContext1.gameObject.SetActive(true);
            NowPage -= 1;
            Page.text = NowPage.ToString();
        }
    }

    public void OncClickNext()//下一页
    {
        if (NowPage < MaxPages)//条件：有下一页的情况下执行
        {
            CardContext1.gameObject.SetActive(false);
            CardContext2.gameObject.SetActive(true);
            NowPage += 1;
            Page.text = NowPage.ToString();
        }
        else
        {
            Debug.Log("没有下一页了！！！");
        }
    }


    public void Show(Card_2Listen card)//放大显示鼠标所在的卡牌
    {
        Showcard.gameObject.SetActive(true);
        Image Cardimage = card.Icon;
        image.sprite = Cardimage.sprite;
    }

    public void HiddenCard(Card_2Listen card)//鼠标离开该卡牌后消失
    {
        Showcard.gameObject.SetActive(false);
    }

    public void Get_Show_AllCard()//获取展示所有卡牌
    {
        StreamReader sr = new StreamReader(@"e:\Card.csv", Encoding.GetEncoding("utf-8"));
        string[] line = new string[20];
        for (int i=0;i<14;i++)
        {
            line[i] = sr.ReadLine();
            Card card = new Card(line[i].ToString().Split(' ')[0], line[i].ToString().Split(' ')[1], line[i].ToString().Split(' ')[2], Convert.ToInt32(line[i].ToString().Split(' ')[3]), Convert.ToInt32(line[i].ToString().Split(' ')[4]), line[i].ToString().Split(' ')[5]);
            LibraryCards.Add(card);
        }

        foreach (var data in LibraryCards)
        {
            if (NowNum < MaxPageNum)
            {
                GameObject Card = GameObject.Instantiate(Cardprefab, CardContext1.transform) as GameObject;
                Card.GetComponent<InstanceCard>().SetCard(data);//挂载生成卡牌的基本信息
                Card.GetComponent<InstanceCard>().SetImage(data.CardName1);//设置卡牌的图片
                CardLibrarys.Add(Card);
                NowNum += 1;
            }
            else
            {
                GameObject Card = GameObject.Instantiate(Cardprefab, CardContext2.transform) as GameObject;
                Card.GetComponent<InstanceCard>().SetCard(data);//挂载生成卡牌的基本信息
                Card.GetComponent<InstanceCard>().SetImage(data.CardName1);//设置卡牌的图片
                CardLibrarys.Add(Card);
            }

        }
    }
}
