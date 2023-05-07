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

    public GameObject[] waypoints;
    private GameObject currWaypoint;
    private int waypointIndex;
    private float minDist;
    public Rigidbody2D rb;
    private GameController lgamecontroller;
    private WaveSpawner ws;
    
    public HealthBar healthBar;

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
    }

    // Update is called once per frame
    void Update()
    {
        //if current position is close to the next waypoint
        if (Vector3.Distance(currWaypoint.GetComponent<Transform>().position,transform.position) <= minDist)
        {
            //If not at the last waypoint
            Debug.Log("WaypointIndex: " + waypointIndex + " ArrayLength: " + waypoints.Length);
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

        //TESTING PURPOSES TO TEST HEALTH BAR
        if (Input.GetKeyDown(KeyCode.Space))
        {
            current_health -= 10f;
            healthBar.SetHealth(current_health); 
        }
    



        //point to the currWaypoint and move in that direction
        // transform.up = currWaypoint.GetComponent<Transform>().position - transform.position;
        //  rb.velocity = transform.up * speed * Time.smoothDeltaTime;


        






    }

    private void FixedUpdate()
    {
        //point to the currWaypoint and move in that direction
        transform.up = currWaypoint.GetComponent<Transform>().position - transform.position;
        rb.velocity = transform.up * speed * Time.smoothDeltaTime;
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

    //if the current health is less than 0, destroy the enemy
    private void HealthChecker()
    {
        //if the enemy health is less or = to zero 
        if(current_health <= 0)
        {
            //add 1 to the number of enemies killed in gamecontroller script
            //ws.UpdateKilledEnemies();

            //destroy the egg
            Destroy(gameObject);
        }
    }

}
