using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Vector3 positionInKeyboard;
    public string _name = "";
    private bool _inKeyboard =true;
    private bool _inPad = false;
    private bool _outKeyboard = false;

    public bool OutKeyboard { get => _outKeyboard; set => _outKeyboard = value; }
    public bool InPad { get => _inPad; set => _inPad = value; }
    public bool InKeyboard { get => _inKeyboard; set => _inKeyboard = value; }

    private void Start()
    {

        positionInKeyboard = gameObject.transform.position;
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
        moveTo(positionInKeyboard);
    }

    public void moveTo(Vector3 position)
    {
        position.y = 0;
        transform.position = position;
    }

    public void outOfGame()
    {
        OutKeyboard = false;
        InKeyboard = false;
        InPad = false;
        Destroy(transform.gameObject);
    }
}
