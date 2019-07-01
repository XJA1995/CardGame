using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonRoundEnd : MonoBehaviour
{
    public GameControll controll;
    public Text text;
    public static ButtonRoundEnd Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void ButtonClick()//按钮按下后更改按钮sprite
    {
        //回合结束
      //  controll.TransformPlayer();

        StartCoroutine(controll.RoundEnd());
    }
}
