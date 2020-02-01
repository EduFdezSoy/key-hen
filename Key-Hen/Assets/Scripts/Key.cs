using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private Transform positionInKeyboard;
    public string _name = "";
    private bool _inKeyboard =true;
    private bool _inPad = false;
    private bool _outKeyboard = false;

    private void Start()
    {
        positionInKeyboard = gameObject.transform;
    }

    public void moveOut()
    {
        _outKeyboard = true;
        _inKeyboard = false;
        _inPad = false;
    }

    public void moveToPad()
    {
        _outKeyboard = false;
        _inKeyboard = false;
        _inPad = true;
    }

    public void moveBack()
    {
        _outKeyboard = false;
        _inKeyboard = true;
        _inPad = false;
    }

    public void outOfGame()
    {
        _outKeyboard = false;
        _inKeyboard = false;
        _inPad = false;
    }
}
