using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{

    private DateTime time;
    private GameController gameController;

    public Text EnemiesKilledUI;

    // Start is called before the first frame update
    void Start()
    {
        time = System.DateTime.Now;

        gameController = FindObjectOfType<GameController>();
        UpdateHighScoreUI();
    }

    // Update is called once per frame
    void Update()
    {
        DateTime temp = System.DateTime.Now;
        TimeSpan delta = temp - time;

        //if (delta.Seconds > 20)
        //{
        //    MainMenu();
        //}



       // Debug.Log(delta.Seconds);
    }

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

    public void UpdateHighScoreUI()
    {
        int high_score = PlayerPrefs.GetInt("Total Number of Mobs Killed");
        EnemiesKilledUI.text = "Enemies Killed: " + high_score;
    }
}
