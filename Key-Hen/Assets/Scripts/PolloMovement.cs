using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Link this to something
public class PolloMovement : MonoBehaviour
{

    public GameObject pollo;

    // Start is called before the first frame update
    void Start()
    {
        setDestiny();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void setDestiny()
    {
        // select target from key array
        Vector3[] destinos = {
            new Vector3(-10f, 0f, 10f),
            new Vector3(10f, 0f, -10f),
            new Vector3(-10f, 0f, -10f),
            new Vector3(10f, 0f, 10f)
        };

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
