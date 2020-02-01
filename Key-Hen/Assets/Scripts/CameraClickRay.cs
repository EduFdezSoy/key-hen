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
                if (hit.collider.gameObject.tag.Equals("Key"))
                {
                    if (hit.collider.gameObject.GetComponent<Key>().OutKeyboard)
                    {
                        hit.collider.gameObject.GetComponent<Key>().moveToPad();
                    }
                }
            }
        }

    }
}
