using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead : MonoBehaviour
{
    public bool amDead;
    public Pause pause;


    public GameObject deathScreen;

    public Sway sway;

    public GameObject enemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (amDead)
        {
            StartCoroutine(DeadRoutine());
            pause.look.enabled = false;
            pause.move.enabled = false;
            pause.leaning.enabled = false;
            pause.canPause = false;
            enemy.SetActive(false);
        }
        else
        {
            pause.look.enabled = true;
            pause.move.enabled = true;
            pause.leaning.enabled = true;
            pause.canPause = true;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public IEnumerator DeadRoutine()
    {
        sway.enabled = false;
        yield return new WaitForSeconds(3.5f);
        Time.timeScale = 0f;

        deathScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
