﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Link this to the Pollo object
public class PolloBehaviour : MonoBehaviour
{
    // public fields
    float movement = 0.1f;
    float timeToMove = 0.001f;

    // private fields
    private Vector3 destino = new Vector3(10f, 0f, -10f);
    private Vector3 newVector = new Vector3();
    private float lastChangeTime = 0f;

    // getters and setters
    public Vector3 Destino { get => destino; set => destino = value; }

    // Start is called before the first frame update
    void Start()
    {
        destino.y = transform.position.y;
        newVector.y = transform.position.y;
        lastChangeTime = Time.time;

        StartCoroutine(MoveDuck());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

    }

    private IEnumerator MoveDuck()
    {
        newVector.x = transform.position.x;
        newVector.z = transform.position.z;

    Debug.Log(Vector3.Distance(transform.position, Destino));
        Debug.Log((movement * 2));

        if (Vector3.Distance(transform.position, Destino) < (1))
        {
            // BERD IS ON THE TARGET
            Debug.Log("estoy");
        }
        else
        {
            // MOVE BERD
            if (Destino.x > transform.position.x)
                newVector.x = transform.position.x + movement;
            else if (Destino.x < transform.position.x)
                newVector.x = transform.position.x - movement;

            if (Destino.z > transform.position.z)
                newVector.z = transform.position.z + movement;
            else if (Destino.z < transform.position.z)
                newVector.z = transform.position.z - movement;


            transform.position = newVector;
        }
    
        yield return new WaitForSeconds(timeToMove);
        StartCoroutine(MoveDuck());
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
