using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill
{

    public string playName;

    public string effect;

    public int damage;

    public int BossArmor;

    public int BossPower;

    void Use()
    {
        switch (playName)
        {
            case "attack":
                Hero.Instance.Hurt(damage);
                break;
            case "attack1":
                Hero.Instance.Hurt(damage);
                break;
            case "attack2":
                Hero.Instance.Hurt(damage);
                break;
            case "attack3":
                Hero.Instance.Hurt(damage);
                break;
            case "attack4":
                Hero.Instance.Hurt(damage);
                break;
            case "Armor":
                Boss.Instance.AddBoss_Armor(BossArmor);
                break;
            case "Armor1":
                Boss.Instance.AddBoss_Armor(BossArmor);
                break;
            case "Armor2":
                Boss.Instance.AddBoss_Armor(BossArmor);
                break;
            case "Armor3":
                Boss.Instance.AddBoss_Armor(BossArmor);
                break;
            case "Armor4":
                Boss.Instance.AddBoss_Armor(BossArmor);
                break;
            case "Power":
                Boss.Instance.AddBossPower(BossPower);
                break;
            case "Power1":
                Boss.Instance.AddBossPower(BossPower);
                break;
            case "Power2":
                Boss.Instance.AddBossPower(BossPower);
                break;
            case "Power3":
                Boss.Instance.AddBossPower(BossPower);
                break;
            case "Power4":
                Boss.Instance.AddBossPower(BossPower);
                break;
            default:
                Debug.Log("error");
                break;
        }
        BossEffectC.Instance.BossAnimatinEvent.finish -= Use;
    }

    public void Effect(string Name,string effect)
    {
        Vector2 position = new Vector2(45, 45);
        Vector2 position1 = new Vector2(337, 205);

        this.playName = Name;
        switch (effect)
        {
            case "BossAttack":
                {
                    BossEffectC.Instance.Play(effect, position);
                    BossEffectC.Instance.BossAnimatinEvent.finish += Use;
                }
                break;
            case "BossBuff":
                {
                    BossEffectC.Instance.Play(effect, position1);
                    BossEffectC.Instance.BossAnimatinEvent.finish += Use;
                }
                break;
            default:
                Debug.Log("error");
                break;
        }
    }
    
}
