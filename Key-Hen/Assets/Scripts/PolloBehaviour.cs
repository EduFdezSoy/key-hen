using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Link this to the Pollo object
public class PolloBehaviour : MonoBehaviour
{
    // public fields
    float movement = 5f;
    float timeToMove = 0.001f;

    // private fields
    private Vector3 destino = new Vector3(10f, 0f, -10f);
    private Vector3 newVector = new Vector3();
    private float lastChangeTime = 0f;

    // getters and setters
    public Vector3 Destino { get => destino; set => destino = value; }

    public  KeyboardController keyboardController;

    // Start is called before the first frame update
    void Start()
    {
        while (!keyboardController.hasArrayReady())
        {

        }
        destino.y = transform.position.y;
        newVector.y = transform.position.y;
        lastChangeTime = Time.time;

        StartCoroutine(MoveDuck());

        keyboardController.dropOutKey(1);
        keyboardController.dropOutKey(2);
        keyboardController.dropOutKey(3);
        keyboardController.dropOutKey(4);
    }

    private IEnumerator MoveDuck()
    {
        newVector.x = transform.position.x;
        newVector.z = transform.position.z;

   // Debug.Log(Vector3.Distance(transform.position, Destino));
    //    Debug.Log((movement * 2));

        // MOVE BERD
        Vector3 desp = Vector3.MoveTowards(transform.position, Destino, Time.deltaTime * movement) - transform.position;
        transform.position += desp;

    
        yield return new WaitForSeconds(timeToMove);
        StartCoroutine(MoveDuck());
        StartCoroutine(TakeKey());
    }
    private IEnumerator TakeKey()
    {
        yield return new WaitForSeconds(0.1f);
    }

    /// Bigger the time, more probabilities to change the bird mind
    ///
    /// max says the seconds when the probability rise to 50%, max/2 or minus wont allow a mind change 
    ///
    /// Returns: bool, true if changes her way
    public bool ChangeBerdMind() {
        float diff = Time.time - lastChangeTime;
        int max = 3;
        float percentage = 100/max * diff;
        float rand = Random.Range(0f, percentage);

        if (rand > 50)
        {
            lastChangeTime = Time.time;
            return true;
        } else {
            return false;
        }
    }
}
