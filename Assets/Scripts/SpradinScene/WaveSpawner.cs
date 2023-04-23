using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class WaveSpawner : MonoBehaviour
{
    private bool spawnWave = false;
    private GameController lgamecontroller;
    private float timeSinceSpawn = 0;
    private float spawnRate = 1f;  


    // Start is called before the first frame update
    void Start()
    {
        lgamecontroller= FindObjectOfType<GameController>();
     
    }

    // Update is called once per frame
    void Update()
    {
        
        spawnWave = lgamecontroller.spawnWave;
        
        GameObject[] wayPoints = lgamecontroller.getWaypoints();

        if(spawnWave)
        {
            //start the enemies;
            if ((Time.time - timeSinceSpawn) > spawnRate || timeSinceSpawn == 0)
            {
                GameObject e = Instantiate(Resources.Load("Prefabs/Sprad_Enemy") as GameObject);
                timeSinceSpawn = Time.time;
                e.GetComponent<Sprad_Enemy>().waypoints = wayPoints;
                
            }





        }



        
    }
}
