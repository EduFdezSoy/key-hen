using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolloBehaviour : MonoBehaviour
{
    public Vector3 vector = new Vector3(10f, 0f, -10f);
     float movement = 0.1f;
     float timeToMove = 0.001f;

    // Start is called before the first frame update
    void Start()
    {
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
        Vector3 newVector = new Vector3();

        if (vector.x > transform.position.x)
            newVector.x = transform.position.x + movement;
        else if (vector.x < transform.position.x)
            newVector.x = transform.position.x - movement;

        if (vector.z > transform.position.z)
            newVector.z = transform.position.z + movement;
        else if (vector.z < transform.position.z)
            newVector.z = transform.position.z - movement;

        if (vector.x == transform.position.x)
            newVector.x = transform.position.x;
        if (vector.z == transform.position.z)
            newVector.z = transform.position.z;

        transform.position = newVector;
        
        yield return new WaitForSeconds(timeToMove);
        StartCoroutine(MoveDuck());
    }
}
