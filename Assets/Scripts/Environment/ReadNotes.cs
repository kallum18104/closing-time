using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ReadNotes : MonoBehaviour
{
    public GameObject noteUI;


    public GameObject pickUpText;

    public AudioSource pickUpSound;

    public bool inReach;

    public Pause pause;

    public Sway sway;

    void Start()
    {
        noteUI.SetActive(false);

        pickUpText.SetActive(false);

        inReach = false;
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickUpText.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }




    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && inReach)
        {
            noteUI.SetActive(true);
            pickUpSound.Play();

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pickUpText.SetActive(false);
            pause.look.enabled = false;
            pause.move.enabled = false;
            pause.leaning.enabled = false;
            pause.move.Source.enabled = false;
            pause.move.SourceRun.enabled = false;
            pause.canPause = false;
            sway.enabled = false;
        }
        
    }


    public void ExitButton()
    {

        noteUI.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pause.look.enabled = true;
        pickUpText.SetActive(true);

        pause.move.enabled = true;
        pause.leaning.enabled = true;
        pause.canPause = false;
        sway.enabled = true;


    }
}
