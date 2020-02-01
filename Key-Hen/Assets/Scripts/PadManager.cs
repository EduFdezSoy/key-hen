using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadManager : PositionControler
{

    void FixedUpdate()
    {
        for (int i = 0; filledKeycode.Length > i; i++)
        {
            if (Input.GetKeyDown(filledKeycode[i]))
            {
                takeLetter(i);
            }
        }
    }
}
