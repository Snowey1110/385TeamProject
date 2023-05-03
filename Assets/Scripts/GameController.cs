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


    // Start is called before the first frame update
    void Start()
    {
        //set public variables
        health = 1000;
        gameStart = 5f;
        timeToWave.text = "Waves start in " + gameStart.ToString("F0") + " seconds.";

        //get handle on Map object
        map = FindObjectOfType<MapScript>();
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




}
