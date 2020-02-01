using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionControler : MonoBehaviour
{
    GameObject _fatherPositions;
    public Transform[] _positions;
    protected bool[] filledPositions;
    protected string[] filledKeycode;

    private void Start()
    {
        filledPositions = new bool[_positions.Length];
        filledKeycode = new string[_positions.Length];
    }

    public int isFilledOut(string keycode)
    {
        for (int i = 0; i < filledPositions.Length; i++)
        {
            if (!filledPositions[i])
            {
                fillSpace(i);
                fillKeyCode(i, keycode);
                return i;
            }
        }
        return -1;
    }

    private void fillKeyCode(int pos, string keycode)
    {
        filledKeycode[pos] = keycode;
    }

    public void fillSpace(int pos)
    {
        filledPositions[pos] = true;
    }

    public void takeLetter(int pos)
    {
        filledPositions[pos] = false;
        filledKeycode[pos] = String.Empty;
    }
}
