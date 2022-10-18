using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnlockDoor : MonoBehaviour
{
    public float timeToGet;
    public float timer;

    [SerializeField] private GrabKey _keyGrab;

    [SerializeField] private GameObject _unlockText;

    public Slider progress;

    public GameObject progressObj;

        void OnTriggerStay(Collider plyr)
        {
            if ((plyr.gameObject.tag == "Player") &&(_keyGrab.keyGrabbed))
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
                if (timer<= 0)
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

    private void Update()
    {
        progress.value = timer;

        if(timer >= timeToGet)
        {
            SceneManager.LoadScene("End");
        }
    }

}
