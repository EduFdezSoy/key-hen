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
            if (filledKeycode[i] != null && filledKeycode[i] != "" && Input.GetKeyDown(filledKeycode[i].ToLower()))
            {
                for (int j = 0; j < listado.Length; j++)
                {
                    if (listado[j] != null && listado[j].GetComponent<Key>() != null && listado[j].GetComponent<Key>()._name != null && listado[j].GetComponent<Key>()._name != "" && listado[j].GetComponent<Key>()._name.Equals(filledKeycode[i]))
                    {
                        listado[j].GetComponent<Key>().moveBack();
                        keyboardController.getBackElement(listado[j].GetComponent<Key>());
                        resetPosition(i);
                        GameManager.instance.addPoints();
                    }
                }
            }
        }
    }

    private void resetPosition(int i)
    {
        filledKeycode[i] = "";
        filledPositions[i] = false;
         
    }
}
