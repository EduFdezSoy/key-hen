using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadManager : PositionControler
{
    private GameObject[] listado;
    private void Start()
    {
        filledPositions = new bool[8];
        filledKeycode = new string[8];
        listado = GameObject.FindGameObjectsWithTag("Key");
    }
    void FixedUpdate()
    {
        for (int i = 0; filledKeycode.Length > i; i++)
        {
            if (filledKeycode[i] != null && Input.GetKeyDown(filledKeycode[i]))
            {
                for (int j = 0; j < listado.Length; j++)
                {
                    if (listado[j].GetComponent<Key>()._name.Equals(filledKeycode[i]))
                   {
                        listado[j].GetComponent<Key>().moveBack();
                        //Todo: Avisar al key manager
                   }
                }
            }
        }
    }

   
}
