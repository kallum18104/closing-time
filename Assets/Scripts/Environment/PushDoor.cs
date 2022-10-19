using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushDoor : MonoBehaviour
{
    private void OnCollisionStay(Collision other)
    {
        if (other.transform.CompareTag("DoorLeft"))
        {
            Debug.Log("Hit Left");
            RotateDoorLeft(other.gameObject);
        }

        if (other.transform.CompareTag("DoorRight"))
        {
            Debug.Log("Hit Right");
            RotateDoorRight(other.gameObject);
        }
    }

    private void RotateDoorLeft(GameObject door)
    {
        var desiredRotQ = Quaternion.Euler(door.transform.eulerAngles.x, 90, door.transform.eulerAngles.z);
        door.transform.rotation = Quaternion.Lerp(door.transform.rotation, desiredRotQ, Time.deltaTime * 10);
    }

    private void RotateDoorRight(GameObject door)
    {
        var desiredRotQ = Quaternion.Euler(door.transform.eulerAngles.x, -90, door.transform.eulerAngles.z);
        door.transform.rotation = Quaternion.Lerp(door.transform.rotation, desiredRotQ, Time.deltaTime * 10);
    }
}
