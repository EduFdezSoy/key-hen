using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadManager : PositionControler
{
    private void Start()
    {
        filledPositions = new bool[10];
    }
    void FixedUpdate()
    {
        for (int i = 0; filledKeycode.Length > i; i++)
        {
            if (Input.GetKeyDown(filledKeycode[i]))
            {
                
            }
        }
    }

   
}
