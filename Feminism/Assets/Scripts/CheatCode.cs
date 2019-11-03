using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCode : MonoBehaviour
{
    public static CheatCode instance;
    public string[] code;
    private int cheatIndex;
    private bool hasCheated = false;
    [HideInInspector] public CatState catState = CatState.cat;


    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        else
            instance = this;
    }

    private void Update()
    {
        if (!hasCheated)
            GetCode();
    }

    private void GetCode()
    {
        if (Input.anyKeyDown)
        {
            string currentKey = Input.inputString;
            if (currentKey == code[cheatIndex])
            {
                cheatIndex++;
                if (cheatIndex == code.Length)
                {
                    hasCheated = true;
                    catState = CatState.trex;
                }
            }
            else
            {
                cheatIndex = 0;
            }
        }
    }
}
