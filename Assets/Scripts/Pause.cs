using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject Menu;

    public PlayerLook look;
    public PlayerMovement move;
    public Lean leaning;
    public HeadBob bob;

    public bool canPause;

    void Start()
    {
        canPause = true;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape)) && canPause)
        {
            Time.timeScale = 0f;
            Menu.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            look.sensX = 0;
            look.sensY = 0;
            move.enabled = false;
            leaning.lerpTime = 0f;
            move.Source.enabled = false;
            move.SourceRun.enabled = false;
            bob.bobbingAmount = 0f;

        }
    }

    public void resume()
    {
        Time.timeScale = 1f;
        Menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        look.sensX = 120;
        look.sensY = 120;
        move.enabled = true;
        leaning.lerpTime = 0.05f;
        bob.bobbingAmount = 0.05f;


        //     move.Source.enabled = true;
        //     move.SourceRun.enabled = true;

    }

    public void Quit()
    {
        Application.Quit();
    }
}
