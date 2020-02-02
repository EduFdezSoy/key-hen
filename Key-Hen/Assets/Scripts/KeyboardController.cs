using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    public GameObject[] keysOnKeyboardInit;
    public GameObject[] keysOnKeyboardCurrent;
    private bool arrayReady =false;
    public PositionControler positionControler;

    private int lastPos;
    
    void Start()
    {
        WithForLoop();

    }
    IEnumerator Ordena()
    {
     
        if (arrayReady)
        {

            Vector3 original;
            Vector3 actual;
            for (int i = 0; i < keysOnKeyboardCurrent.Length; i++)
            {
                if (keysOnKeyboardCurrent[i]!= null) {
                    actual = keysOnKeyboardCurrent[i].transform.position;
                    original = keysOnKeyboardCurrent[i].GetComponent<Key>().positionInKeyboard;
                    Debug.Log(Vector3.Distance(original, actual));
                    if (Vector3.Distance(original, actual) < 0.01)
                    {
                        keysOnKeyboardCurrent[i].GetComponent<Key>().moveTo(keysOnKeyboardCurrent[i].GetComponent<Key>().positionInKeyboard);
                    }
                }
            }
        }
        yield return new WaitForSeconds(2f);
        StartCoroutine(Ordena());
    }
  
    void WithForLoop()
    {
        int children = transform.childCount;
        int keyNumber = 0;
        for (int i = 0; i < children; i++)
        {
            if (transform.GetChild(i).gameObject.tag.Equals("Key"))
            {
                keyNumber++;
            }
        }
        keysOnKeyboardInit = new GameObject[keyNumber];
        keysOnKeyboardCurrent = new GameObject[keyNumber];
        for (int i = 0; i < children; ++i)
        {
            if (transform.GetChild(i).gameObject.tag.Equals("Key"))
            {
                if (transform.GetChild(i).gameObject.GetComponent<Key>() != null && transform.GetChild(i).gameObject.GetComponent<Key>()._name != "")
                {
                    keysOnKeyboardInit[i] = transform.GetChild(i).gameObject;
                    keysOnKeyboardCurrent[i] = transform.GetChild(i).gameObject;
                }
            }
        }
        arrayReady = true;

        StartCoroutine(Ordena());
    }

    public void getBackElement(Key key)
    {
        for (int i = 0; i < keysOnKeyboardInit.Length; i++)
        {
            if (keysOnKeyboardInit[i] != null && keysOnKeyboardInit[i].GetComponent<Key>() != null && keysOnKeyboardInit[i].GetComponent<Key>()._name.Equals(key._name))
            {
                keysOnKeyboardCurrent[i] = keysOnKeyboardInit[i];
            }
        }
    }

    public bool hasArrayReady()
    {
        return arrayReady;
    }
    public GameObject[] getArray()
    {
        return keysOnKeyboardInit;
    }

    public GameObject[] getArrayNotTakens()
    {
        return keysOnKeyboardCurrent;
    }

    public void dropOutKey(int pos)
    {
        if (lastPos != pos)
        {
            lastPos = pos;
            dropKey(pos);
        }
    }

    private void dropKey(int pos)
    {
        if (keysOnKeyboardCurrent[pos] != null)
        {
            keysOnKeyboardCurrent[pos] = null;

            int valor = positionControler.isFilledOut(keysOnKeyboardInit[pos].GetComponent<Key>());
            if (valor == -1)
            {
                GameManager.instance.takeDamage();
                keysOnKeyboardInit[pos].GetComponent<Key>().outOfGame();
            }
            else
            {
                keysOnKeyboardInit[pos].GetComponent<Key>().moveOut();
            }
        }
    }
}
