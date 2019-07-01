using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HeroInfo : MonoBehaviour
{
    public string[] heroName;

    public void OnClick(int index)
    {
        PlayerPrefs.SetString("HeroName", heroName[index]);
        SceneManager.LoadScene("FightGame");//要切换到的场景名
    }
}
