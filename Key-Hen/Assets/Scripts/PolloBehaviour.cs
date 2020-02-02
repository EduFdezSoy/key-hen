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
    private Vector3 destino = new Vector3(10f, 2f, -10f);
    private Vector3 newVector = new Vector3(0f, 2f, 0f);
    private float lastChangeTime = 0f;

    // getters and setters
    public Vector3 Destino { get => destino; set => destino = value; }
    public Key keycode;
    public int position;

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

        if (Vector3.Distance(transform.position, Destino) < 0.2f)
        {
            StartCoroutine(TakeKey());
        }

        yield return new WaitForSeconds(timeToMove);
        StartCoroutine(MoveDuck());
    }
    private IEnumerator TakeKey()
    {
        yield return new WaitForSeconds(1f);
        if (keycode != null)
        {
            keycode.moveOut();
            keyboardController.dropOutKey(position);
        }
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
