using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    public GameObject[] keysOnKeyboardInit;
    public GameObject[] keysOnKeyboardCurrent;
    private bool arrayReady;
    public PositionControler positionControler;

    void Start()
    {
        WithForLoop();
    }

    void WithForLoop()
    {
        int children = transform.childCount;
        keysOnKeyboardInit = new GameObject[children];
        for (int i = 0; i < children; ++i)
        {
            if(transform.GetChild(i).gameObject.tag.Equals("Key"))
            keysOnKeyboardInit[i] = transform.GetChild(i).gameObject;
        }
        arrayReady = true;
        keysOnKeyboardCurrent = keysOnKeyboardInit;
    }
    public bool hasArrayReady()
    {
        return arrayReady;
    }
    public GameObject[] getArray()
    {
        return keysOnKeyboardInit;
    }

    public void dropOutKey(int pos)
    {
        keysOnKeyboardCurrent[pos] = null;
        keysOnKeyboardInit[pos].GetComponent<Key>().moveOut();

        // if -1 mata la pieza
        positionControler.isFilledOut(keysOnKeyboardInit[pos].GetComponent<Key>());
    }
}
