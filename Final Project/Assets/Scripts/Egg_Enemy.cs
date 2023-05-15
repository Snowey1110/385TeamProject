using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg_Enemy : MonoBehaviour
{

    //Edit in prefab inspector menu
    public float speed;
    public float damage;

    public float max_health;
    private int current_health;

    public int deposit;

    public GameObject[] waypoints;
    private GameObject currWaypoint;
    private int waypointIndex;
    private float minDist;
    public Rigidbody2D rb;
    private GameController lgamecontroller;
    private WaveSpawner ws;
    private Shop shopScript;
    
    public HealthBar healthBar;

    private float freezeTime;
    public bool isFrozen = false;

    // Start is called before the first frame update
    void Start()
    {
        //When created the first waypoint is start
        waypointIndex = 0;
        currWaypoint = waypoints[waypointIndex];
        transform.position = currWaypoint.transform.position;
        

        //get a handle on the rigidbody2D component to use later
        rb = GetComponent<Rigidbody2D>();
        lgamecontroller = FindObjectOfType<GameController>();
        ws = FindObjectOfType<WaveSpawner>();

        //get shop script
        shopScript = FindObjectOfType<Shop>();

        //SET VARIABLES IN PREFAB MENU
        //set public variables
        //speed = 60f;
        minDist = 0.04f;

        //sets the healthbar health
        healthBar = FindObjectOfType<HealthBar>();
        current_health = Mathf.RoundToInt(max_health);
        healthBar.SetMaxHealth(current_health);

        ////set enemy to random color
        //Color temp = GetComponent<Renderer>().material.color;
        //temp = new Color(Random.Range(0.5f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
        //GetComponent<Renderer>().material.SetColor("_Color", temp);

        //just in case there is no value already set in
        if(deposit == 0)
        {
            deposit = 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if current position is close to the next waypoint
        if (Vector3.Distance(currWaypoint.GetComponent<Transform>().position,transform.position) <= minDist)
        {
            //If not at the last waypoint
            //Debug.Log("WaypointIndex: " + waypointIndex + " ArrayLength: " + waypoints.Length);
            if(waypointIndex < (waypoints.Length - 1))
            {
                waypointIndex++;
                currWaypoint = waypoints[waypointIndex];
            }
            else
            {
                ws.destroyEnemy(this.gameObject);
            }
        }

        HealthChecker();

        Freeze(freezeTime);
    }

    private void FixedUpdate()
    {
        transform.up = currWaypoint.GetComponent<Transform>().position - transform.position;
        if (isFrozen == true)
        {
            rb.velocity = transform.up * (0.375f * speed) * Time.smoothDeltaTime;
        }
        else
        {
            rb.velocity = transform.up * speed * Time.smoothDeltaTime;
        }
    }

    public float GetDamage()
    {
        return damage;
    }

    //other script calls this to do damage to the enemy
    public void DamageEnemy(float damage_val)
    {
        //converts the incoming float to an int
        int damage_int = Mathf.RoundToInt(damage_val);

        //subtract the damage taken from the current enemy health
        current_health -= damage_int;

        //update the healthbar
        healthBar.SetHealth(current_health);
    }

    public void Freeze(float curTime)
    {
        freezeTime = curTime;
        if (Time.time - freezeTime >= 5f)
        {
            isFrozen = false;
        }
        else
        {
            isFrozen = true;
            return;
        }
    }

    //if the current health is less than 0, destroy the enemy
    private void HealthChecker()
    {
        //IF YOU WANT TO HAVE SOMETHING HAPPEN WHEN AN ENEMY DIES
        //PUT IT HERE
        //if the enemy health is less or = to zero 
        if(current_health <= 0)
        {
            //add 1 to the number of enemies killed in gamecontroller script
            ws.IncreaseKilledEnemies();

            //add 10 to the balance each time enemy is killed
            shopScript.BalanceDeposit(deposit);

            //destroy the egg
            Destroy(gameObject);
        }
    }
}
