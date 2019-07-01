using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    public float DeadTime = 1f;
    float Time1 = 0;
 
    public void FightShow()
    {
        Time1 += Time.deltaTime;
        if (Time1 >= DeadTime)
        {
            this.transform.localScale = new Vector3(0f, 0f, 0f);
        }
    }
}
