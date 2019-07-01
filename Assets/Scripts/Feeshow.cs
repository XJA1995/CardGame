using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Feeshow : MonoBehaviour
{
    public int InitialFee = 4;
    public Text text;

    public static Feeshow Instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetFee(int fee)
    {
        InitialFee = fee;
        text.text = InitialFee.ToString();

    }

    public bool UseFee(int fee)//使用费用
    {
        
        if(InitialFee >= fee)
        {
            InitialFee -= fee;
            text.text = InitialFee.ToString();
            return true;
        }
            return false;
    }

    public void AddFee(int fee)//卡牌效果加费用
    {
        InitialFee += fee;
    }
}
