﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Return : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("StartGame");//要切换到的场景名
    }
}
