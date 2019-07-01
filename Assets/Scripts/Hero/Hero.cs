using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hero : MonoBehaviour, Info
{
    public Image image = null;
    public Text text;//血量
    public Sprite sprite;
    public int MaxHp = 30;
    public int MinHp = 0;
    private int HpCount = 30;

    private int ArmorNum = 0;
    private int PowerNum = 0;
    private int ThornsNum = 0;

    private Text ArmorValue;//护甲值
    private Text PowerValue;//力量值
    private Text ThornsValue;//反伤值

    private bool ArmorFlag = false;
    private bool PowerFlag = false;

    private GameObject Canvas;
    private GameObject Canvas1;


    public static Hero Instance { get; private set; }//单例


    void Awake()
    {
        Instance = this;
        ArmorValue = GameObject.Find("ArmorValue").GetComponent<Text>();
        PowerValue = GameObject.Find("PowerValue").GetComponent<Text>();
        ThornsValue = GameObject.Find("ThornsValue").GetComponent<Text>();
        Canvas = GameObject.Find("Canvas");
        Canvas1 = GameObject.Find("Canvas1");

        Canvas1.gameObject.SetActive(false);


        SetImage();
    }

    void Start()
    {

    }

    public void SetArmorFlag(bool flag)
    {
        ArmorFlag = flag;
    }

    public void SetPowerFlag(bool flag)
    {
        PowerFlag = flag;
    }

    public void SetImage()
    {
        print(Date.Instance.HeroName);
        sprite = Resources.Load<Sprite>(Date.Instance.HeroName);
        image.sprite = sprite;
    }

    public void Re_SetHero()//重新设置英雄属性
    {
        ArmorNum = 0;
        PowerNum = 0;
        ShowArmor(ArmorNum);
        ShowPower(PowerNum);
    }

    public void PlusHp(int hp)//回血
    {
        HpCount += hp;
        if (HpCount > MaxHp)
        {
            HpCount = MaxHp;
        }
        ShowHP(HpCount);
    }

    public void SetPower()
    {
        if (PowerFlag)
        {
            PowerNum -= 4;
            ShowPower(PowerNum);
            PowerFlag = false;
        }
        else
        {
            ShowPower(PowerNum);
        }
        Debug.Log(PowerNum);
    }

    public void SetArmor()
    {
        if (ArmorFlag)
        {
            ShowArmor(ArmorNum);
        }
        else
        {
            ArmorNum = 0;
            ShowArmor(ArmorNum);
        }
    }

    public void ShowArmor(int armor)//显示护甲值
    {
        ArmorValue.text = armor.ToString();
    }

    public void ShowHP(int hp)//显示血量
    {
        text.text = hp.ToString();
    }

    public void ShowPower(int power)//显示力量
    {
        PowerValue.text = power.ToString();
    }

    public void AddPower(int power)//加力量
    {
        PowerNum += power;
        ShowPower(PowerNum);
    }

    public void CutPower(int power)//减力量
    {
        PowerNum -= power;
        ShowPower(PowerNum);
    }

    public int GetPower()//返回力量值
    {
        return PowerNum;
    }

    public void AddArmor(int armor)//加甲
    {
        ArmorNum += armor;
        ShowArmor(ArmorNum);
    }

    public void SetThorns(int thorns)
    {
        ThornsValue.text = thorns.ToString();
    }

    public void AddThorns(int thorns)//加反伤值
    {
        ThornsNum += thorns;
        SetThorns(ThornsNum);
    }

    public void CutThorns(int thorns)//减
    {
        ThornsNum -= thorns;
        SetThorns(ThornsNum);
    }

    public int GetThorns()//返回反伤值
    {
        return ThornsNum;
    }

    public int GetArmor()
    {
        return ArmorNum;
    }


    void Update()
    {

    }


    public void CombatEnter(int w)
    {



    }


    public bool IsDie()
    {
        return HpCount <= MinHp;
    }

    public void RoundStart(int cardCount, Action endCall)
    {

    }

    public void Hurt(int Damage)
    {
        int AddPowerDamage = Boss.Instance.GetBossPower();

        if (ArmorNum >= (Damage + AddPowerDamage))
        {
            ArmorNum -= (Damage + AddPowerDamage);
            ShowArmor(ArmorNum);
        }
        else
        {
            HpCount = HpCount + ArmorNum - Damage - AddPowerDamage;
            ArmorNum = 0;
            ShowArmor(ArmorNum);
            if (HpCount <= MinHp)//回到主界面
            {
                Canvas.gameObject.SetActive(false);
                Canvas1.gameObject.SetActive(true);
            }
            ShowHP(HpCount);
        }
    }
}

public interface Info
{
    void CombatEnter(int w);
    void RoundStart(int cardCount, Action endCall);
    bool IsDie();
    void Hurt(int dmg);
}