using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun_Enemy : MonoBehaviour
{

    //Edit in prefab inspector menu
    public float speed;
    public float damage;

    public float max_health;
    public int current_health;

    public GameObject[] waypoints;
    private GameObject currWaypoint;
    private int waypointIndex;
    private float minDist;
    public Rigidbody2D rb;
    private GameController lgamecontroller;
    private WaveSpawner ss;
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
        ss = FindObjectOfType<WaveSpawner>();

        //get shop script
        shopScript = FindObjectOfType<Shop>();

        minDist = 0.04f;

        //sets the healthbar health
        healthBar = FindObjectOfType<HealthBar>();
        healthBar.SetMaxHealth(max_health);
        healthBar.SetHealth(max_health);
    }

    // Update is called once per frame
    void Update()
    {
        //if current position is close to the next waypoint
        if (Vector3.Distance(currWaypoint.GetComponent<Transform>().position, transform.position) <= minDist)
        {
            //If not at the last waypoint
            //Debug.Log("WaypointIndex: " + waypointIndex + " ArrayLength: " + waypoints.Length);
            if (waypointIndex < (waypoints.Length - 1))
            {
                waypointIndex++;
                currWaypoint = waypoints[waypointIndex];
            }
            else
            {
                ss.destroyEnemy(this.gameObject);
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
        if (Time.time - freezeTime >= 3f)
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
        if (current_health <= 0)
        {
            ss.IncreaseKilledEnemies();
            ss.springDelay();

            //add 100 to the balance each time enemy is killed
            shopScript.BalanceDeposit(100);

            //destroy the sun
            Destroy(gameObject);
        }
    }

    public void SetHealth(float health)
    {
        max_health = health;
        current_health = Mathf.RoundToInt(max_health);
    }
}
