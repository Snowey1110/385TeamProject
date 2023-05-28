using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
    public void SoundMenu()
    {
        SceneManager.LoadScene("Sound");
    }
    public void MainMenu() 
    { 
        SceneManager.LoadScene("Game Menu");
    }
    public void CreditMenu()
    {
        SceneManager.LoadScene("Credits");
    }
}