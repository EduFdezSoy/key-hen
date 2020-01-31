using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClickRay : MonoBehaviour
{
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            { 
                //TODO: Le dice a la ficha o pajaro que se mueva
            }
            Debug.Log("You selected the " + hit.transform.name);
        }

    }
}
