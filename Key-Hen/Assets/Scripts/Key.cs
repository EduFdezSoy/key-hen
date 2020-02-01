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

    public bool OutKeyboard { get => _outKeyboard; set => _outKeyboard = value; }
    public bool InPad { get => _inPad; set => _inPad = value; }
    public bool InKeyboard { get => _inKeyboard; set => _inKeyboard = value; }

    private void Start()
    {
        positionInKeyboard = gameObject.transform;
    }

    public void moveOut()
    {
        OutKeyboard = true;
        InKeyboard = false;
        InPad = false;
    }

    public void moveToPad()
    {
        OutKeyboard = false;
        InKeyboard = false;
        InPad = true;
    }

    public void moveBack()
    {
        OutKeyboard = false;
        InKeyboard = true;
        InPad = false;
    }

    public void outOfGame()
    {
        OutKeyboard = false;
        InKeyboard = false;
        InPad = false;
    }

    private void FixedUpdate()
    {
        
    }
}
