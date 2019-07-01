using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatinEvent : MonoBehaviour
{

    //public event System.Action trigger;
    public event System.Action finish;


    /*public void TriggerClip()
    {
        trigger?.Invoke();
    }*/

    public void End()//判断动画结束
    {
        print("End");
        finish?.Invoke();
    }

}
