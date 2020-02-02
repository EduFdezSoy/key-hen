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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void setDestiny()
    {
        GameObject[] destinosGO = keyboardController.getArray();

        Vector3[] destinos = new Vector3[destinosGO.Length];

        for (int i = 0; i < destinosGO.Length; i++)
        {
            destinos[i] = destinosGO[i].transform.position + new Vector3(0,1,0);
        }

        // send the destiny to the berd to start moving it
        pollo.GetComponent<PolloBehaviour>().Destino = destinos[Random.Range(0, destinos.Length)];
        
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
