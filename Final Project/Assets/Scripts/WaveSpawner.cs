using JetBrains.Annotations;
//using Packages.Rider.Editor.UnitTesting;
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

    private bool round_1 = true;
    private bool round_2 = false;
    private bool round_3 = false;
    private bool round_4 = false;

    private bool springIsComing = false;

    private int number_killed = 0;

    /////////////////////////////////////////////////////////////
    //setting to true will send 1 mob and have then drop markers 
    //when targeted by a tower
    //bool test = true;
    /////////////////////////////////////////////////////////////


    // Start is called before the first frame update
    void Start()
    {
        //set local variables
        spawnRate = 1f;

        //get handle on Gamecontroller object
        lgamecontroller = FindObjectOfType<GameController>();


        
    }

    // Update is called once per frame
    void Update()
    {
        //get bool from game controller to start spawning
        spawnWave = lgamecontroller.spawnWave;

        //get array of test points from map
        GameObject[] wayPoints = lgamecontroller.getWaypoints();

        checkRound();


        ////for targeting testing of towers
        //if (test)
        //{
        //    GameObject e = Instantiate(Resources.Load("Prefabs/Egg_Enemy") as GameObject);
        //    e.GetComponent<Egg_Enemy>().waypoints = wayPoints;
        //    test = false;
        //}


        if (spawnWave)
        {
            //start the enemies; (This will need to become an alogorith that spawns differenty types at specific rates)
            if ((Time.time - timeSinceSpawn) > spawnRate || timeSinceSpawn == 0)
            {
                //checks what round/difficulty/wave we are on
                if (round_1)
                {
                    GameObject e = Instantiate(Resources.Load("Prefabs/Egg_Enemy") as GameObject);
                    timeSinceSpawn = Time.time;
                    e.GetComponent<Egg_Enemy>().waypoints = wayPoints;
                }
                else if (round_2)
                {
                    //depending on number, spawn that type of enemy in this particular round
                    int obj_decider = randSpawner();

                    //60% chance of basic enemy spawning
                    if (obj_decider == 0)
                    {
                        GameObject e = Instantiate(Resources.Load("Prefabs/Egg_Enemy") as GameObject);
                        timeSinceSpawn = Time.time;
                        e.GetComponent<Egg_Enemy>().waypoints = wayPoints;
                    }
                    else if (obj_decider == 1)
                    {
                        GameObject e = Instantiate(Resources.Load("Prefabs/Egg_Enemy") as GameObject);
                        timeSinceSpawn = Time.time;
                        e.GetComponent<Egg_Enemy>().waypoints = wayPoints;
                    }
                    //33% chance of second enemy type spawning
                    else if (obj_decider == 2)
                    {
                        GameObject e = Instantiate(Resources.Load("Prefabs/Egg_Enemy_2") as GameObject);
                        timeSinceSpawn = Time.time;
                        e.GetComponent<Egg_Enemy>().waypoints = wayPoints;
                    }
                }
                else if (round_3)
                {
                    int obj_decider = randSpawner();

                    //33% chance of all types spawning
                    if (obj_decider == 0)
                    {
                        GameObject e = Instantiate(Resources.Load("Prefabs/Egg_Enemy") as GameObject);
                        timeSinceSpawn = Time.time;
                        e.GetComponent<Egg_Enemy>().waypoints = wayPoints;
                    }
                    else if (obj_decider == 1)
                    {
                        GameObject e = Instantiate(Resources.Load("Prefabs/Egg_Enemy_2") as GameObject);
                        timeSinceSpawn = Time.time;
                        e.GetComponent<Egg_Enemy>().waypoints = wayPoints;
                    }
                    else if (obj_decider == 2)
                    {
                        GameObject e = Instantiate(Resources.Load("Prefabs/Egg_Enemy_3") as GameObject);
                        timeSinceSpawn = Time.time;
                        e.GetComponent<Egg_Enemy>().waypoints = wayPoints;
                    }
                }
                else if (round_4)
                {
                    int obj_decider = randSpawner();

                    if (springIsComing == false)
                    {
                        GameObject s = Instantiate(Resources.Load("Prefabs/Sun_Enemy") as GameObject);
                        s.GetComponent<Egg_Enemy>().waypoints = wayPoints;
                        springIsComing = true;
                    }

                    //33% chance of all types spawning
                    if (obj_decider == 0)
                    {
                        GameObject e = Instantiate(Resources.Load("Prefabs/Egg_Enemy") as GameObject);
                        timeSinceSpawn = Time.time;
                        e.GetComponent<Egg_Enemy>().waypoints = wayPoints;
                    }
                    else if (obj_decider == 1)
                    {
                        GameObject e = Instantiate(Resources.Load("Prefabs/Egg_Enemy_2") as GameObject);
                        timeSinceSpawn = Time.time;
                        e.GetComponent<Egg_Enemy>().waypoints = wayPoints;
                    }
                    else if (obj_decider == 2)
                    {
                        GameObject e = Instantiate(Resources.Load("Prefabs/Egg_Enemy_3") as GameObject);
                        timeSinceSpawn = Time.time;
                        e.GetComponent<Egg_Enemy>().waypoints = wayPoints;
                    }
                }
            }
        }

    }

    //destroys enemy AND depletes the user health
    public void destroyEnemy(GameObject obj)
    {
        //accesses the egg's method
        Egg_Enemy enemy = obj.GetComponent<Egg_Enemy>();

        //get user health
        float user_health = lgamecontroller.health;

        //subtract the enemy damage from user's health
        user_health -= enemy.GetDamage();

        lgamecontroller.health = user_health;

        Debug.Log("User Health: " + lgamecontroller.health);

        //lgamecontroller.health--;
        Destroy(obj);

        //number of enemies killed
        //UpdateKilledEnemies(); //<- commented it out because not techincally killed
    }

    //TESTING PURPOSES
    //ROUND 1 0-5 DEATHS
    //ROUND 2 5-10 DEATHS
    //ROUND 3 10+ DEATHS

    //REAL VALUES SHOULD BE
    //ROUND 1 0-20 DEATHS
    //ROUND 2 20-40 DEATHS
    //ROUND 3 40+ DEATHS
    //ROUND 4 100+ KILLS
    public void checkRound()
    {
        if(number_killed < 20)
        {
            round_1 = true;
            round_2 = false;
            round_3 = false;
            round_4 = false;
            lgamecontroller.UpdateWaveUI(1);
            //Debug.Log("ROUND 1 " + number_killed);
        }
        else if(number_killed >= 20 && number_killed < 40)
        {
            round_1 = false;
            round_2 = true;
            round_3 = false;
            round_4 = false;
            lgamecontroller.UpdateWaveUI(2);
            //Debug.Log("ROUND 2 " + number_killed);
        }
        else if(number_killed >= 40)
        {
            round_1 = false;
            round_2 = false;
            round_3 = true;
            round_4 = false;
            lgamecontroller.UpdateWaveUI(3);
            //Debug.Log("ROUND 3 " + number_killed);
        }
        else if (number_killed >= 100)
        {
            round_1 = false;
            round_2 = false;
            round_3 = false;
            round_4 = true;
            lgamecontroller.UpdateWaveUI(4);
        }
    }

    //picks random number between 1-3
    private int randSpawner()
    {
        int decider_num = Random.Range(0, 3);
        return decider_num;
    }

    //increases the number of killed enemies by one
    public void IncreaseKilledEnemies()
    {
        number_killed++;
    }

    //returns the number_killed private variable
    public int GetNumberKilled()
    {
        return number_killed;
    }

}
