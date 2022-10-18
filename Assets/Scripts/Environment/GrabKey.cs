using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKey : MonoBehaviour
{
    [SerializeField]private GameObject _grabText;

    public bool keyGrabbed;

    public GameObject keyObject;

    void OnTriggerStay(Collider plyr)
    {
        if (plyr.gameObject.tag == "Player")
        {
            _grabText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                _grabText.SetActive(false);
                keyGrabbed = true;
                keyObject.SetActive(false);
            }
        }
    }

    void OnTriggerExit(Collider plyr)
    {
        if (plyr.gameObject.tag == "Player")
        {
            _grabText.SetActive(false);
        }
    }
}
