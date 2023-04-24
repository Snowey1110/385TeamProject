using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprad_Enemy : MonoBehaviour
{

    public float speed;
    public float health;
    public GameObject[] waypoints;
    private GameObject currWaypoint;
    private int waypointIndex;
    private float minDist;
    public Rigidbody2D rb;
    private GameController lgamecontroller;
    private WaveSpawner ws;


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


        //set public variables
        speed = 500f;
        minDist = 0.02f;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        //if current position is close to the next waypoint
        if(Vector3.Distance(currWaypoint.GetComponent<Transform>().position,transform.position) <= minDist)
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
        
        //point to the currWaypoint and move in that direction
        transform.up = currWaypoint.GetComponent<Transform>().position - transform.position;
        rb.velocity = transform.up * speed * Time.smoothDeltaTime;

       
    }

   


}
