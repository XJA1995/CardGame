using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    Cardgenerating,//系统随机发牌阶段
    PlayCard,//出牌对战阶段
    End//游戏结束阶段
}

public enum BossState
{
    StartPhase,//boss回合开始阶段
    PerformPhase,//boss执行操作阶段
    EndPhase//boss回合结束阶段

}

public class GameControll : MonoBehaviour
{
    public GameState gameState = GameState.Cardgenerating;

    public BossState bossState = BossState.StartPhase;

    //public CardGroup cardGroup;
    public CardManage cardManage;
    public Feeshow feeshow;
    public ButtonRoundEnd roundEnd;

    public GameObject UseLand;

    private Text Tips;
    private Button RoundEndButton;

    //public Fight fight;
    public Hero hero;
    public Boss boss;

    public Text text;

    public static GameControll Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        Tips = GameObject.Find("Tips").GetComponent<Text>();
        RoundEndButton = GameObject.Find("RoundEndButton").GetComponent<Button>();
    }

    private void Start()
    {
        feeshow = Feeshow.Instance;
        hero = Hero.Instance;
        roundEnd = ButtonRoundEnd.Instance;
        StartCoroutine(InitRound(4));
    }

    void Update()
    {

    }







    /*IEnumerator Wait(float duration)//等待时间
    {
        for (float timer = 0; timer < duration; timer += Time.deltaTime)
            yield return 0;
    }*/


    public IEnumerator RoundEnd()//玩家回合结束
    {
        yield return null;
        //转换角色
        RoundEndButton.enabled = false;
        boss.Use(RoundStart);//进入怪物回合，回合结束时执行RoundStart()即玩家回合开始

    }

    void RoundStart()//玩家回合开始
    {
        StartCoroutine(InitRound(2));//系统发牌两张
    }


    public IEnumerator InitRound(int count)//玩家回合开始
    {
        UseLand.gameObject.SetActive(false);//发牌时不可以出牌

        hero.SetArmor();//重置英雄属性
        hero.SetPower();
        feeshow.SetFee(4);
        RoundEndButton.enabled = true;

        for (int i = 0; i < count; i++)
        {
            SendCard();
            yield return new WaitForSeconds(0.7f);
        }

        UseLand.gameObject.SetActive(true);
    }
    //public void TransformPlayer()//
    //{
    //    //转换角色
    //    RoundEndButton.enabled = false;


    //}

    public void SendCard()//发牌
    {


        if (cardManage.MAXHandCard())
        {
            cardManage.Re_Shuffle();//判断牌库中是否有牌可发
            cardManage.RandomCreateCard();
            cardManage.CardMove(); ;
            //StartCoroutine(Wait(2f));
        }

        

    }

    public void SendCards(int j)//接下来的关卡中初始发牌
    {
        for (int i = 0; i < j; i++)
        {
            SendCard();
        }
    }

}
