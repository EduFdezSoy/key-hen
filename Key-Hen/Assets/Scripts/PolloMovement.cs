using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Link this to something
public class PolloMovement : MonoBehaviour
{
    public GameObject pollo;
    public KeyboardController keyboardController;
    // Start is called before the first frame update
    void Start()
    {
        while (!keyboardController.hasArrayReady())
        {

        }
        setDestiny();
    }

    private void setDestiny()
    {
        GameObject[] destinosGO = keyboardController.getArrayNotTakens();

        Vector3[] destinos = new Vector3[destinosGO.Length];

        for (int i = 0; i < destinosGO.Length; i++)
        {
            if(destinosGO[i] != null)
            destinos[i] = destinosGO[i].transform.position + new Vector3(0,2,0);
        }

        // send the destiny to the berd to start moving it
        int random = Random.Range(0, destinos.Length);
        if (destinosGO[random] != null)
        {
            pollo.GetComponent<PolloBehaviour>().Destino = destinos[random];
            pollo.GetComponent<PolloBehaviour>().keycode = destinosGO[random].GetComponent<Key>();
            pollo.GetComponent<PolloBehaviour>().position = random;
        }
        
        StartCoroutine(ThinkMovement());
    }

    private IEnumerator ThinkMovement()
    {
        if(pollo.GetComponent<PolloBehaviour>().ChangeBerdMind())
            setDestiny();
        else
        {
            yield return new WaitForSeconds(1);
            StartCoroutine(ThinkMovement());
        }
    }
}
