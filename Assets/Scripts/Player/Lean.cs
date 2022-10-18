using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lean : MonoBehaviour
{
    public Transform peakLeft;
    public Transform peakRight;
    public Transform idlePosition;


    public float lerpTime =  0.15f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q) || (Input.GetMouseButton(4)))
        {
            transform.position = Vector3.Lerp(transform.position, peakLeft.position, lerpTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, peakLeft.rotation, lerpTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, idlePosition.position, lerpTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, idlePosition.rotation, lerpTime);
        }

        if (Input.GetKey(KeyCode.E) || (Input.GetMouseButton(3)))
        {
            transform.position = Vector3.Lerp(transform.position, peakRight.position, lerpTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, peakRight.rotation, lerpTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, idlePosition.position, lerpTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, idlePosition.rotation, lerpTime);
        }
    }
}
