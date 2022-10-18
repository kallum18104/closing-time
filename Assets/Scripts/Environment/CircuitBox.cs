using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitBox : MonoBehaviour
{
    private bool _energyOn = false;
    [SerializeField] private GameObject _Lights;
    [SerializeField] private GameObject _turnOnText;

    void Start()
    {
        _Lights.SetActive(false);   
    }



    void OnTriggerStay(Collider plyr)
    {
        if (plyr.gameObject.tag == "Player")
        {
            _turnOnText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F) && (!_energyOn))
            {
                _energyOn = true;
                _Lights.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider plyr)
    {
        if (plyr.gameObject.tag == "Player")
        {
            _turnOnText.SetActive(false);
        }
    }
}
