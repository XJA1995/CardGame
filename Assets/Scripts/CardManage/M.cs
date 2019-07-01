using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class M : MonoBehaviour
{
    public event Action<int> EnterCombat;
    public event Action RoundStart;
    public event Action RoundEnd;
    public event Action QuitCombat;

    Info player;
    Info emeny;

    bool currentPlayer;


    public void CombatEnter()
    {
        CreatCombat(StartRound);
        GameControll.Instance.SendCards(4);
    }


    public void StartRound()
    {
        Info r = currentPlayer ? player : emeny;
        r.RoundStart(2, EndRound);
    }


    public void Round(Info target)
    {
        if (target.IsDie())
        {
            CombatQuit();
            return;
        }
    }


    public void EndRound()
    {
         
    }


    public void CombatQuit()
    {
        QuitCombat?.Invoke();
    }


    void CreatCombat(Action callback)
    {
        callback?.Invoke();
    }
}
