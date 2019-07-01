using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


//鼠标对卡牌的操作
public class CardListen : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerClickHandler
{
    public string index;
    RectTransform rectTransform;
    public CardManage handCardManage;
    public Boss boss;
    public Hero hero;
    public CardGroup generator;
    public Feeshow feeshow;
    public ShowCard showCard;
    public ChooseCards chooseCards;
    public GameControll gameControll;
    //public GameObject ThisCard;

    public Image Icon { get; private set; }

    bool enableUse;
    bool CanClick = false;

    public void SetClick(bool can)
    {
        CanClick = can;
    }

    public void GetClick()
    {
        if (chooseCards.GetFlag())
        {
            SetClick(true);
        }
        else
        {
            SetClick(false);
        }
    }

    public void SetUse(bool en)//判断是否进入可出牌区域
    {
        enableUse = en;
    }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        Icon = GetComponent<Image>();
    }
    private void Start()
    {
        handCardManage = CardManage.Instance;
        boss = Boss.Instance;
        generator = CardGroup.Instance;
        feeshow = Feeshow.Instance;
        hero = Hero.Instance;
        showCard = ShowCard.Instance;
        chooseCards = ChooseCards.Instance;
        gameControll = GameControll.Instance;
    }

    public void OnDrag(PointerEventData eventData)//实现鼠标拖拽效果
    {
        //rectTransform.anchoredPosition = eventData.position;
        rectTransform .position = eventData.position;
    }

    public void OnPointerEnter(PointerEventData eventData)//实现鼠标悬浮在卡牌上时
    {
        showCard.Show(this);//放大在特定位置显示该卡牌
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rectTransform.localScale = new Vector3(1f, 1f, 1f);
        showCard.HiddenCard(this);
    }

    public void OnBeginDrag(PointerEventData eventData)//鼠标拖拽前
    {
        eventData.pressPosition = rectTransform.position;
        Icon.raycastTarget = false;
    }

    public void OnEndDrag(PointerEventData eventData)//鼠标拖拽后，对卡牌进行操作
    {
        rectTransform.position = eventData.pressPosition;
        Vector2 position = new Vector2(45, 45);
        InstanceCard card = eventData.pointerDrag.GetComponent<InstanceCard>();
        if (enableUse)//将该卡牌放入弃牌堆  执行该卡牌的效果   更新手中卡牌的位置
        {

            int _fee = card.GetCard().Fee;
            int _value = card.GetCard().Value;
            string _cardType = card.GetCard().CardType;
            string _play = card.GetCard().Play;



            if (feeshow.UseFee(_fee))//判断卡牌费用是否足够
            {
                handCardManage.LoseCard(card.gameObject);
                handCardManage.UpdateShow();
                if(_play .Equals("Buff")||_play .Equals ("armor"))
                {
                    CardEffect(position, _play, _cardType, _value);
                }
                else
                {
                    CardEffect(eventData.position, _play, _cardType, _value);
                }
               
            }
            /*for (int i = 0; i < generator.CardNames.Length; i++)
            {
                if (index.ToString() == generator.CardNames[0])
                {
                    if(feeshow .UseFee(1))
                    {
                        handCardManage.LoseCard(card);
                        handCardManage.UpdateShow();
                        hero.PlusHp(5);
                    }
                    break;
                }
                else if (index.ToString() == generator.CardNames[1])
                {
                    if (feeshow.UseFee(1))
                    {
                        handCardManage.LoseCard(card);
                        handCardManage.UpdateShow();
                        boss.TakeDamage(5);
                    }
                    break;
                }
            }*/


        }
        Icon.raycastTarget = true;
    }

    string cardType;
    int value;

    void Use()
    {

        print("Use");

        switch (cardType)
        {
            case "attack"://普通攻击
                boss.TakeDamage(value);
                break;
            case "armor"://普通防御
                hero.AddArmor(value);
                break;
            case "attack_attackPlusNow"://痛击
                {
                    boss.TakeDamage(value);
                    hero.AddPower(4);
                    hero.SetPowerFlag(true);
                }
                break;
            case "armor_draw"://耸肩无视
                {
                    hero.AddArmor(value);
                    gameControll.SendCard();
                }
                break;
            case "attack_armor"://铁斩波
                {
                    hero.AddArmor(value);
                    boss.TakeDamage(value);
                }
                break;
            case "attack_draw"://剑柄打击
                {
                    boss.TakeDamage(value);
                    gameControll.SendCard();
                }
                break;

            case "attackarmor"://全身撞击
                {
                    boss.TakeDamage(hero.GetArmor());
                }
                break;
            case "draw"://战斗专注
                {
                    gameControll.SendCards(value);
                }
                break;
            case "armor_thornsPlusNow"://火焰屏障（反伤未实现）
                {
                    hero.AddArmor(value);
                }
                break;
            case "attackPlusNow"://活动肌肉
                {
                    hero.AddPower(value);
                    hero.SetPowerFlag(true);
                }
                break;
            case "attackDoublePlus"://突破极限
                {
                    hero.AddPower(hero.GetPower());
                }
                break;
            case "attackPlus"://燃烧
                {
                    hero.AddPower(value);
                }
                break;
            case "armorDoublePlus"://巩固
                {
                    hero.AddArmor(hero.GetArmor());
                }
                break;
            case "armorPlus"://壁垒
                {
                    hero.SetArmorFlag(true);
                }
                break;
            default:
                Debug.Log("error");
                break;
        }
        print("jie绑");
        EffectCtrl.Instance.AnimatinEvent.finish -= Use;
    }


    public void CardEffect(Vector2 position, string play, string cardType, int value)//卡牌的执行效果及动画播放
    {
        this.cardType = cardType;
        this.value = value;
        print("Ani " + play);
        if (string.IsNullOrEmpty(play)) { Use(); return; }
        EffectCtrl.Instance.Play(play, position);//播放paly字段指定的动画
        EffectCtrl.Instance.AnimatinEvent.finish += Use;
    }


    public void OnPointerClick(PointerEventData eventData)//鼠标单击效果（只有当进入选卡界面时才生效）
    {
        GetClick();
        if (CanClick)//
        {
            GameObject card = eventData.pointerDrag;
            handCardManage.AddCardGroups(card);
        }
    }
}