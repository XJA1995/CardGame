using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public Image image = null;
    public Text Boss_Hp;

    private Text Boss_ArmorValue;
    private Text Boss_PowerValue;

    private int BossPowerNum = 0;
    private int BossArmorNum = 0;

    public Hero hero;

    public static Boss Instance { get; private set; }//单例

    //public Sprite sprite;
    public int MaxHp = 30;
    public int MinHp = 0;
    private int HpCount = 30;

    public ChooseCards chooseCards;
    public CardManage cardManage;

    List<Skill> Boss1skills;
    List<Skill> Boss2skills;
    List<Skill> Boss3skills;

    private int CheckNum = 1;
    public string[] BossName;

    List<Card> VictoryCards;

    void Start()
    {
        chooseCards = ChooseCards.Instance; 
        hero = Hero.Instance;
        cardManage = CardManage.Instance;

        Boss1skills = new List<Skill>() { new Skill() { playName = "attack",damage = 5,effect = "BossAttack" } ,//伤害
                                     new Skill() { playName = "attack1",damage = 10,effect = "BossAttack" } ,
                                     new Skill() { playName = "attack2",damage = 15,effect = "BossAttack" } ,
                                     new Skill() { playName = "Armor",BossArmor = 5,effect = "BossBuff" } ,
                                     new Skill() { playName = "Armor1",BossArmor = 10,effect = "BossBuff" },
                                     new Skill() { playName = "Armor2",BossArmor = 15,effect = "BossBuff" } ,
                                     new Skill() { playName = "Power",BossPower = 2,effect = "BossBuff" },
                                     new Skill() { playName = "Power1",BossPower = 4,effect = "BossBuff"},
                                     new Skill() { playName = "Power2",BossPower = 6,effect = "BossBuff"},                          
                                   };
        Boss2skills = new List<Skill>() {new Skill() { playName = "attack1",damage = 10,effect = "BossAttack" } ,
                                     new Skill() { playName = "attack2",damage = 15,effect = "BossAttack" } ,
                                     new Skill() { playName = "attack3",damage = 20,effect = "BossAttack" } ,
                                     new Skill() { playName = "Armor1",BossArmor = 10,effect = "BossBuff" } ,
                                     new Skill() { playName = "Armor2",BossArmor = 15,effect = "BossBuff" } ,
                                     new Skill() { playName = "Armor3",BossArmor = 20,effect = "BossBuff" } ,
                                     new Skill() { playName = "Power1",BossPower = 4,effect = "BossBuff"},
                                     new Skill() { playName = "Power2",BossPower = 6,effect = "BossBuff"},
                                     new Skill() { playName = "Power3",BossPower = 8,effect = "BossBuff"},
                                   };
        Boss3skills = new List<Skill>() {new Skill() { playName = "attack2",damage = 15,effect = "BossAttack" } ,
                                     new Skill() { playName = "attack3",damage = 20,effect = "BossAttack" } ,
                                     new Skill() { playName = "attack4",damage = 25,effect = "BossAttack" } ,
                                     new Skill() { playName = "Armor2",BossArmor = 15,effect = "BossBuff" } ,
                                     new Skill() { playName = "Armor3",BossArmor = 20,effect = "BossBuff" } ,
                                     new Skill() { playName = "Armor4",BossArmor = 25,effect = "BossBuff" } ,
                                     new Skill() { playName = "Power2",BossPower = 6,effect = "BossBuff"},
                                     new Skill() { playName = "Power3",BossPower = 8,effect = "BossBuff"},
                                     new Skill() { playName = "Power4",BossPower = 10,effect = "BossBuff"},
                                   };
    }

    void Awake()
    {
        Instance = this;
        image = this.GetComponent<Image>();

        Boss_ArmorValue = GameObject.Find("Boss_ArmorValue").GetComponent<Text>();
        Boss_PowerValue = GameObject.Find("Boss_PowerValue").GetComponent<Text>();
    }

    public void Re_SetBoss()//重新刷新boss属性
    {
        HpCount = MaxHp + CheckNum *10;
        BossPowerNum = 0;
        BossArmorNum = 0;
        Sprite sprite = Resources.Load<Sprite>(BossName[CheckNum-2]);
        image.sprite = sprite;
        Boss_Hp.text = HpCount.ToString();
        ShowBossArmor(BossArmorNum);
        SetBossPower(BossPowerNum);
    }

    public void AddBoss_Armor(int armor)
    {
        BossArmorNum += armor;
        ShowBossArmor(BossArmorNum);
    }

    public void ShowBossArmor(int armor)//设置护甲
    {
        Boss_ArmorValue.text = armor.ToString();
    }

    public void TakeDamage(int Damage)//伤害
    {
        int AddPowerDamage = hero.GetPower();
        int AddThornsDamage = hero.GetThorns();

        if (BossArmorNum >= (Damage + AddPowerDamage))
        {
            BossArmorNum -= (Damage + AddPowerDamage);
            ShowBossArmor(BossArmorNum);
        }
        else
        {
            HpCount = HpCount + BossArmorNum - Damage - AddPowerDamage - AddThornsDamage;
            BossArmorNum = 0;
            ShowBossArmor(BossArmorNum);
            if (HpCount <= MinHp)
            {
                if (CheckNum  == 3)//保存数据，显示通关界面
                {
                    CheckNum = 1;
                    VictoryCards = cardManage.GetGroups();
                    StreamWriter sw = new StreamWriter(@"e:\Tmp.csv", false);
                    for (int i=0;i< VictoryCards.Count; i++)
                    {
                        var date = VictoryCards[i];
                        var tmp = date.CardName1 + " " + date.Professional + " " + date.CardType + " " + date.Value + " " + date.Fee + " " + date.Play + "\r\n";
                        sw.Write(tmp);
                    }
                    sw.Close();
                    SceneManager.LoadScene("Victory");//要切换到的场景名
                }
                //处理游戏结束逻辑
                CheckNum += 1;
                chooseCards.GetCanChooseCards();
                cardManage.DestroyHandCards();
            }
        }
        
        

        Boss_Hp.text = HpCount.ToString();

    }


    //o target;

    public void Use(System.Action endCall)//怪物回合开始
    {
        //target = hero;
        StartCoroutine(Play(GetSkill(), endCall));//通过协程控制怪物回合
    }
    IEnumerator Play(Skill s, System.Action call)//
    {
        yield return new WaitForSeconds(1);

        print(s.playName);

        //TODO skill

        s.Effect(s.playName,s.effect);//执行怪物的所有操作

        yield return new WaitForSeconds(1);//控制怪物回合执行时间为1s

        call?.Invoke();
    }
    Skill GetSkill()//技能库和技能的选择
    {
        switch (CheckNum)
        {
            case 1:
                return Boss1skills[Random.Range(0, Boss1skills.Count)];
            case 2:
                return Boss2skills[Random.Range(0, Boss1skills.Count)];
            case 3:
                return Boss3skills[Random.Range(0, Boss1skills.Count)];
            default:
                return null;
        }
        /*if (CheckNum == 1)
        {
            if (Boss1skills == null || Boss1skills.Count < 1) return null;

            return Boss1skills[Random.Range(0, Boss1skills.Count)];
        }
        else
        {
            if (CheckNum == 2)
            {
                if (Boss2skills == null || Boss2skills.Count < 1) return null;

                return Boss1skills[Random.Range(0, Boss2skills.Count)];
            }
            else
            {
                if (Boss3skills == null || Boss3skills.Count < 1) return null;

                return Boss1skills[Random.Range(0, Boss3skills.Count)];
            }
        }*/
    }


    public void PlusHp(int hp)//回血
    {
        HpCount += hp;

        if (HpCount > MaxHp)
        {
            HpCount = MaxHp;
        }

        Boss_Hp.text = HpCount.ToString();   
    }

    public void SetBossPower(int power)//设置力量
    {
        Boss_PowerValue.text = power.ToString();
    }

    public void AddBossPower(int power)//加力量
    {
        BossPowerNum += power;
        SetBossPower(BossPowerNum);
    }

    public int GetBossPower()//返回力量值
    {
        return BossPowerNum;
    }



    void Update()
    {

    }
}
