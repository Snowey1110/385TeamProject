using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg_Enemy : MonoBehaviour
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
        speed = 60f;
        minDist = 0.04f;

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



}
