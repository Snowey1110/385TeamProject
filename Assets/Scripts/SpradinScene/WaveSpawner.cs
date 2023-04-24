using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class WaveSpawner : MonoBehaviour
{
    private bool spawnWave = false;
    private GameController lgamecontroller;
    private float timeSinceSpawn = 0;
    private float spawnRate;  


    // Start is called before the first frame update
    void Start()
    {
        //set local variables
        spawnRate = 0.75f;

        //get handle on Gamecontroller object
        lgamecontroller= FindObjectOfType<GameController>();
     
    }

    // Update is called once per frame
    void Update()
    {
        
        //get bool from game controller to start spawning
        spawnWave = lgamecontroller.spawnWave;

        //get array of test points from map
        GameObject[] wayPoints = lgamecontroller.getWaypoints();

        if(spawnWave)
        {
            //start the enemies; (This will need to become an alogorith that spawns differenty types at specific rates)
            if ((Time.time - timeSinceSpawn) > spawnRate || timeSinceSpawn == 0)
            {
                GameObject e = Instantiate(Resources.Load("Prefabs/Sprad_Enemy") as GameObject);
                timeSinceSpawn = Time.time;
                e.GetComponent<Sprad_Enemy>().waypoints = wayPoints;
                
            }
        }

        



    }

    public void destroyEnemy(GameObject obj)
    {
        lgamecontroller.health--;
        Destroy(obj);

    }


}
