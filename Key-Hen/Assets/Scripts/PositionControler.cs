using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionControler : MonoBehaviour
{
    GameObject _fatherPositions;
    public Transform[] _positions;
    protected bool[] filledPositions = new bool[10];
    protected string[] filledKeycode = new string[10];
    public KeyboardController keyboardController;
    public PadManager padManager;

    private GameObject[] keyboardArray;
    private void Start()
    {
        while (!keyboardController.hasArrayReady())
        {

        }
        keyboardArray = keyboardController.getArray();
    }

    public int isFilledOut(Key keycode)
    {
        for (int i = 0; i < filledPositions.Length; i++)
        {
            if (!filledPositions[i])
            {
                fillSpace(i);
                fillKeyCode(i, keycode._name);
                keycode.moveTo(_positions[i]);
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

    public void takeLetter(Key keycode)
    {
        keycode.moveToPad();
        for (int i = 0; i < filledKeycode.Length; i++)
        {
            if (filledKeycode[i].Equals(keycode._name))
            {
                filledPositions[i] = false;
                // if -1 mata la pieza
                keycode.moveToPad();
                padManager.isFilledOut(keycode);
            }
        }
    }
}
