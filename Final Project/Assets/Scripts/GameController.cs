using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public float gameStart;
    public float health;
    public Text timeToWave;
    private MapScript map;
    public bool spawnWave = false;

    //wave status
    public Text currWave;
    private int curr_wave;

    //enemies killed
    public Text enemiesKilled;
    private WaveSpawner ws;
    //private int enemies_killed;


    // Start is called before the first frame update
    void Start()
    {
        //set public variables
        health = 1000;
        gameStart = 5f;
        curr_wave = 0;
        //enemies_killed = 0;

        //set the UI to default values
        timeToWave.text = "Waves start in " + gameStart.ToString("F0") + " seconds.";
        currWave.text = "Current wave: " + curr_wave;
        enemiesKilled.text = "Total Mobs Killed: 0";

        //get handle on Map object
        map = FindObjectOfType<MapScript>();

        //access the wavespawner script
        ws = FindObjectOfType<WaveSpawner>();

    }

    // Update is called once per frame
    void Update()
    {
        
        //Dont spawn waves until time has surpassed gameStart.
        gameStart -= Time.deltaTime;
        if (gameStart <= 0)
        {
            timeToWave.text = "Assault Incomming!";
            spawnWave = true;
        }
        else
        {
            timeToWave.text = "Waves start in " + gameStart.ToString("F0") + " seconds.";
        }

        UpdateKilledEnemiesUI();
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


}