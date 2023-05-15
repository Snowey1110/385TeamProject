using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("Game Menu");
    }

    public void SoundMenu()
    {
        SceneManager.LoadScene("Sound");
    }

    public void ControlMenu()
    {
        SceneManager.LoadScene("Control");
    }

    public void CreditsMenu()
    {
        SceneManager.LoadScene("Credits");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Map_1");
    }
}
