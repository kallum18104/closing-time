using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseLighter : MonoBehaviour
{
    public GameObject fire;

    public bool Open;
    void Start()
    {
        Open = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((!Open) && Input.GetMouseButtonDown(1))
        {
            fire.SetActive(true);
            Open = true;
        }
        else if ((Open) && Input.GetMouseButtonDown(1))
        {
            fire.SetActive(false);
            Open = false;

        }
    }
}
