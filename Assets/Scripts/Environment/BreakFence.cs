using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BreakFence : MonoBehaviour
{
    public GameObject progressObj;
    public GameObject _unlockText;

    public float timeToGet;
    public float timer;

    public Slider progress;

    public SearchDumpsters dumpster;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        progress.value = timer;

        if (timer >= timeToGet)
        {
            SceneManager.LoadScene("End");
        }
    }

    void OnTriggerStay(Collider plyr)
    {
        if ((plyr.gameObject.tag == "Player") && dumpster.screwdriverGrab)
        {
            progressObj.SetActive(true);
            _unlockText.SetActive(true);
            if (Input.GetKey(KeyCode.F))
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    timer = 0;
                }
            }
        }
    }

    void OnTriggerExit(Collider plyr)
    {
        if (plyr.gameObject.tag == "Player")
        {
            progressObj.SetActive(false);
            _unlockText.SetActive(false);
        }
    }
}
