using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public float gameStart;
    public float health;
    public Text timeToWave;
    private MapScript map;
    public bool spawnWave = false;

    //wave status UI
    public Text currWave;
    private int curr_wave;

    //enemies killed UI
    public Text enemiesKilled;
    private WaveSpawner ws;
    //private int enemies_killed = 0;

    //user health/life UI
    public Text healthLifeUI;
    public HealthBar healthBar;

    //Debug note "FOR DEBUG PRESS P"
    public GameObject DebugNote;

    //tower selection
    public String TowerUpgrade;
    public int TowerCost;
    public GameObject selectedTower;

    //money UI
    //public Text moneyUI;
    //private int money;
    private Shop shopScript;

    

    // Start is called before the first frame update
    void Start()
    {
        //GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayMusic();

        //set public variables
        health = 1000;
        gameStart = 5f;
        curr_wave = 0;
        //money = 0;
        //enemies_killed = 0;

        //set the UI to default values
        timeToWave.text = "Waves start in " + gameStart.ToString("F0") + " seconds.";
        currWave.text = "Current wave: " + curr_wave;
        enemiesKilled.text = "Total Mobs Killed: 0";
        healthLifeUI.text = "Health: 1000";
        //moneyUI.text = "Money: $500";

        //get handle on Map object
        map = FindObjectOfType<MapScript>();

        //access the wavespawner script
        ws = FindObjectOfType<WaveSpawner>();

        //access the shop script
        shopScript = FindObjectOfType<Shop>();

        //set the healthbar health
        healthBar = FindObjectOfType<HealthBar>();
        healthBar.SetMaxHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        //Dont spawn waves until time has surpassed gameStart.
        gameStart -= Time.deltaTime;
        if (gameStart <= 0)
        {
            // timeToWave.text = "Assault Incoming!";
            timeToWave.text = "Wave " + curr_wave;
            spawnWave = true;

            DebugNote.SetActive(false);
        }
        else
        {
            timeToWave.text = "Waves start in " + gameStart.ToString("F0") + " seconds.";
        }

        //TESTING PURPOSES TO TEST HEALTH BAR
        if (Input.GetKeyDown(KeyCode.Space))
        {
            health -= 10;
            healthBar.SetHealth(health); 
        }

        UpdateKilledEnemiesUI();
        //UpdateMoneyUI();
        UpdateHealthLifeUI();
        CheckIfDead();

        //update the healthbar
        healthBar.SetHealth(health);
    }

    //getter to give outside scripts read only access to private array of waypoints
    public GameObject[] getWaypoints()
    {
        return map.getWaypoints();
    }

    //getter to give outide scripts access to spanWave boolean variable
    public bool getSpawnWave()
    {
        return spawnWave;
    }

    public void UpdateWaveUI(int wave_num)
    {
        curr_wave = wave_num;
        currWave.text = "Current wave: " + curr_wave;
    }

    //pulls the number of enemies killed from the wavespawner script
    public void UpdateKilledEnemiesUI()
    {
        int enemies_killed = ws.GetNumberKilled();
        enemiesKilled.text = "Total Mobs Killed: " + enemies_killed;
    }

    /* public void UpdateMoneyUI()
    {
        int user_funds = shopScript.GetBalance();
        moneyUI.text = "Money: $" + user_funds;
    } 
    */

    public void UpdateHealthLifeUI()
    {
        healthLifeUI.text = "Health: " + health;
    }

    public void CheckIfDead()
    {
        //TESTING PURPOSES, MAKE SURE TO CHANGE BACK TO 0
        if(health <= 0)
        {
            //get the number of enemies the person has killed
            int max_killed = ws.GetNumberKilled();

            //store it in the player prefab
            PlayerPrefs.SetInt("Total Number of Mobs Killed", max_killed);

            SceneManager.LoadScene("Game Over");
        }
    }

    //restarts the timer wave spawner timer
    public void RestartGameStartTimer()
    {
        //Debug.Log("RestartGameTimerCalled");
        gameStart = 20f;
        spawnWave = false;
    }

    //disable wavespawner
    public void StopSpawning()
    {
        spawnWave = false;
    }

}