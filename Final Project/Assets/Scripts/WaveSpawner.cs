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
    private GameObject[] wayPoints;
    private float timeSinceSpawn = 0;
    private float spawnRate;  

    private bool round_1 = true;
    private bool round_2 = false;
    private bool round_3 = false;
    private bool round_4 = false;

    private Sun_Enemy sun;
    private bool springIsComing = false;
    private bool bossSpawn = false;
    private bool finalBoss = false;
    private int finalCount = 0;

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
        wayPoints = lgamecontroller.getWaypoints();
    }

    // Update is called once per frame
    void Update()
    {
        checkRound();
        roundSpawner();
        bossSpawner();
    }

    //destroys enemy AND depletes the user health
    public void destroyEnemy(GameObject obj)
    {
        //accesses the egg's method
        Egg_Enemy egg = obj.GetComponent<Egg_Enemy>();
        Sun_Enemy sun = obj.GetComponent<Sun_Enemy>();

        //get user health
        float user_health = lgamecontroller.health;

        //subtract the enemy damage from user's health
        if (obj.gameObject.tag == "Enemy")
        { 
            user_health -= egg.GetDamage();
        }

        if (obj.gameObject.name == "Sun_Enemy(Clone)")
        {
            user_health -= sun.GetDamage();
        }

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
    //SUN ROUND 1000+ DEATHS

    //REAL VALUES SHOULD BE
    //ROUND 1 0-40 KILLS
    //ROUND 2 40-100 KILLS
    //ROUND 3 100-200 KILLS
    //ROUND 4 200+ KILLS
    public void checkRound()
    {
        if(number_killed <= 40)
        {
            round_1 = true;
            lgamecontroller.UpdateWaveUI(1);

            if (number_killed == 40)
            {
                springIsComing = true;
                lgamecontroller.RestartGameStartTimer();
                lgamecontroller.UpdateWaveUI(2);
            }
        }

        else if(number_killed > 40 && number_killed <= 100)
        {
            if (number_killed == 41)
            {
                round_1 = false;
                round_2 = true;
            }

            if(number_killed == 100)
            {
                springIsComing = true;
                lgamecontroller.RestartGameStartTimer();
                lgamecontroller.UpdateWaveUI(3);
            }
        }
        else if(number_killed > 100 && number_killed <= 200)
        {
            if (number_killed == 101)
            {
                round_2 = false;
                round_3 = true;
            }

            if(number_killed == 200)
            {
                springIsComing = true;
                lgamecontroller.RestartGameStartTimer();
                lgamecontroller.UpdateWaveUI(4);
            }
        }
        else
        {
            round_4 = true;
            springIsComing = true;

            if (number_killed == 300 && finalBoss == false)
            {
                finalBoss = true;
            }
        }
    }

    public void roundSpawner()
    {
        //get bool from game controller to start spawning
        spawnWave = lgamecontroller.spawnWave;

        if (spawnWave)
        {
            //start the enemies; (This will need to become an alogorith that spawns differenty types at specific rates)
            if ((Time.time - timeSinceSpawn) > spawnRate || timeSinceSpawn == 0)
            {
                //checks what round/difficulty/wave we are on
                if (round_1 == true && bossSpawn == false)
                {
                    GameObject e = Instantiate(Resources.Load("Prefabs/Egg_Enemy") as GameObject);
                    timeSinceSpawn = Time.time;
                    e.GetComponent<Egg_Enemy>().waypoints = wayPoints;

                }
                else if (round_2)
                {
                    //depending on number, spawn that type of enemy in this particular round
                    int obj_decider = randSpawner();


                    if (obj_decider == 0 || obj_decider == 1 || obj_decider == 2)
                    {
                        GameObject e = Instantiate(Resources.Load("Prefabs/Egg_Enemy") as GameObject);
                        timeSinceSpawn = Time.time;
                        e.GetComponent<Egg_Enemy>().waypoints = wayPoints;
                    }

                    //33% chance of second enemy type spawning
                    else if (obj_decider == 3 || obj_decider == 4)
                    {
                        GameObject e = Instantiate(Resources.Load("Prefabs/Egg_Enemy_2") as GameObject);
                        timeSinceSpawn = Time.time;
                        e.GetComponent<Egg_Enemy>().waypoints = wayPoints;
                    }
                }
                else if (round_3)
                {
                    int obj_decider = randSpawner();

                    if (obj_decider == 0 || obj_decider == 1)
                    {
                        GameObject e = Instantiate(Resources.Load("Prefabs/Egg_Enemy") as GameObject);
                        timeSinceSpawn = Time.time;
                        e.GetComponent<Egg_Enemy>().waypoints = wayPoints;
                    }
                    else if (obj_decider == 2 || obj_decider == 3)
                    {
                        GameObject e = Instantiate(Resources.Load("Prefabs/Egg_Enemy_2") as GameObject);
                        timeSinceSpawn = Time.time;
                        e.GetComponent<Egg_Enemy>().waypoints = wayPoints;
                    }
                    else if (obj_decider == 4)
                    {
                        GameObject e = Instantiate(Resources.Load("Prefabs/Egg_Enemy_3") as GameObject);
                        timeSinceSpawn = Time.time;
                        e.GetComponent<Egg_Enemy>().waypoints = wayPoints;
                    }
                }
                else if (round_4)
                {
                    int obj_decider = randSpawner();

                    if (obj_decider == 0)
                    {
                        GameObject e = Instantiate(Resources.Load("Prefabs/Egg_Enemy") as GameObject);
                        timeSinceSpawn = Time.time;
                        e.GetComponent<Egg_Enemy>().waypoints = wayPoints;
                    }
                    else if (obj_decider == 1 || obj_decider == 2)
                    {
                        GameObject e = Instantiate(Resources.Load("Prefabs/Egg_Enemy_2") as GameObject);
                        timeSinceSpawn = Time.time;
                        e.GetComponent<Egg_Enemy>().waypoints = wayPoints;
                    }
                    else if (obj_decider == 3 || obj_decider == 4)
                    {
                        GameObject e = Instantiate(Resources.Load("Prefabs/Egg_Enemy_3") as GameObject);
                        timeSinceSpawn = Time.time;
                        e.GetComponent<Egg_Enemy>().waypoints = wayPoints;
                    }
                }
            }
        }
    }

    public void bossSpawner()
    {
        if (springIsComing == true)
        {
            if (round_1 == true && bossSpawn == false)
            {
                bossSpawn = true;
                GameObject s = Instantiate(Resources.Load("Prefabs/Sun_Enemy") as GameObject);
                s.GetComponent<Sun_Enemy>().waypoints = wayPoints;
                s.GetComponent<Sun_Enemy>().SetHealth(1000f);
            }
            if (round_2 == true && bossSpawn == false)
            {
                bossSpawn = true;
                GameObject s = Instantiate(Resources.Load("Prefabs/Sun_Enemy") as GameObject);
                s.GetComponent<Sun_Enemy>().waypoints = wayPoints;
                s.GetComponent<Sun_Enemy>().SetHealth(3000f);
            }
            if (round_3 == true && bossSpawn == false)
            {
                bossSpawn = true;
                GameObject s = Instantiate(Resources.Load("Prefabs/Sun_Enemy") as GameObject);
                s.GetComponent<Sun_Enemy>().waypoints = wayPoints;
                s.GetComponent<Sun_Enemy>().SetHealth(7000f);
            }
            if (round_4 == true)
            {
                if ((Time.time - timeSinceSpawn) > 10f || timeSinceSpawn == 0)
                {
                    GameObject s = Instantiate(Resources.Load("Prefabs/Sun_Enemy") as GameObject);
                    timeSinceSpawn = Time.time;
                    s.GetComponent<Sun_Enemy>().waypoints = wayPoints;
                    s.GetComponent<Sun_Enemy>().SetHealth(12000f);
                }
            }
            if (finalBoss == true && finalCount < 1)
            {
                GameObject s = Instantiate(Resources.Load("Prefabs/Sun_Enemy") as GameObject);
                timeSinceSpawn = Time.time;
                s.GetComponent<Sun_Enemy>().waypoints = wayPoints;
                s.GetComponent<Sun_Enemy>().SetHealth(100000f);
                finalBoss = false;
                finalCount++;
            }
        }
    }

    //checks if any enemies are still present on the map
    public bool AreEnemiesPresent()
    {
        GameObject[] enemies_present = GameObject.FindGameObjectsWithTag("Enemy");

        //if array is empty, no enemies are present
        if(enemies_present.Length <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    //picks random number between 1-3
    private int randSpawner()
    {
        int decider_num = Random.Range(0, 5);
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

    public void springDelay()
    {
        springIsComing = false;
        bossSpawn = false;

    }
}
