using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*public enum Professional //枚举职业
{
    mage,//法师
    soldier,//战士
    hunter//猎人
}

public enum CardType //枚举卡牌类型
{
    attack,//攻击牌
    armor,//护甲牌
    addLifevalue,//回血牌
    attackPlus,//永久攻击增益牌（打出后销毁，进入销毁牌堆，本局对战中不在出现）
    armorPlus,//永久护甲增益
    thornsPlus,//永久反伤增益
    attackPlusNow,//当前回合攻击增益（打出后不销毁，进入弃牌堆，可循环使用）
    armorPlusNow,//当前回合护甲增益
    thornsPlusNow,//当前回合反伤增益
}

public enum Value //枚举卡牌的作用数值
{
    zore,//卡牌的作用数值为0 
    one,
    tow,
    three,
    four,
    five,
    six,
    seven,
    eight,
    nine,
    ten,
    eleven,
    twelve,
    thirteen,
    fourteen,
    fifteen,
    sixteen,
    seventeen,
    eighteen
}

public enum Fee //枚举卡牌的费用
{
    feezore,//费用为0
    feeone,
    feetwo,
    feethree,
    feefour,
}*/

public class Card //卡牌的基本信息
{
    private string CardName;//卡牌名字
    private string professional;//卡牌所属职业
    private string cardType;//卡牌类型
    private int value;//卡牌的作用数值
    private int fee;//卡牌的费用
    private string play;

    public Card(string CardName , string professional, string cardType, int value, int fee,string play)//构造函数
    {
        this.CardName1 = CardName;
        this.Professional = professional;
        this.CardType = cardType;
        this.Value = value;
        this.Fee = fee;
        this.play = play;
    }

    public string Professional { get => professional; set => professional = value; }
    public string CardType { get => cardType; set => cardType = value; }
    public int Value { get => value; set => this.value = value; }
    public int Fee { get => fee; set => fee = value; }
    public string CardName1 { get => CardName; set => CardName = value; }
    public string Play { get => play; set => play = value; }
}

