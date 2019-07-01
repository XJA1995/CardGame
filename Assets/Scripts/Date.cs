using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Date //储存各种数据
{

    static Date ins;
    public static Date Instance
    {
        get
        {
            if (ins == null)
                ins = new Date();
            return ins;
        }
    }

    public readonly string HeroName;

    Date()
    {
       string heroName = PlayerPrefs.GetString("HeroName");
        HeroName = heroName;
    }


    private string heroChoose;//选择的英雄名

    public Date(string HeroChoose)
    {
        this.HeroChoose = HeroChoose;
    }

    public string HeroChoose { get => heroChoose; set => heroChoose = value; }

    /*public void SetHeroName(string name)
    {
        HeroChoose = name;
    }

    public string GetHeroName()
    {
        return HeroChoose;
    }*/
}
