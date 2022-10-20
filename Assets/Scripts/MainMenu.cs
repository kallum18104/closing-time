using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _micUI;
    [SerializeField] private GameObject _mainMenu;

    public void PlayGame()
    {
        SceneManager.LoadScene("The Shop");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MicrophoneUI()
    {
        _micUI.SetActive(false);
        _mainMenu.SetActive(true);
    }
}
