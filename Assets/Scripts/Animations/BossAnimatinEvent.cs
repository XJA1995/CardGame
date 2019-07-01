using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimatinEvent : MonoBehaviour
{
    public event System.Action finish;
    public void End()
    {
        print("End");
        finish?.Invoke();
    }
}
