using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{

    //public float mp_x;
    //public float mp_y;
    //public float mp_z;
    public float gameStart;
    public Text timeToWave;
    private MapScript map;
    public bool spawnWave = false;


    // Start is called before the first frame update
    void Start()
    {
        gameStart = 5f;
        timeToWave.text = "Waves start in " + gameStart.ToString("F0") + " seconds.";
        map = FindObjectOfType<MapScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //logging mouse position for testing 
        //mp_x = Input.mousePosition.x;
        //mp_y = Input.mousePosition.y;
        //mp_z = Input.mousePosition.z;
        //Debug.Log("x: " + mp_x + " y: " + mp_y + " z: " + mp_z);

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


    public GameObject[] getWaypoints()
    {
        return map.getWaypoints();
    }
    public bool getSpawnWave()
    {
        return spawnWave;
    }




}
