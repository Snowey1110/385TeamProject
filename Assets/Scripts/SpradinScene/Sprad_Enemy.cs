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


    // Start is called before the first frame update
    void Start()
    {
        waypointIndex = 0;
        currWaypoint = waypoints[waypointIndex];
        
        //PointAtPosition(currWaypoint.GetComponent<Transform>().position, Time.deltaTime);
        transform.position = currWaypoint.transform.position;
        rb = GetComponent<Rigidbody2D>();
       
        speed = 500f;
        minDist = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        
        

        if(Vector3.Distance(currWaypoint.GetComponent<Transform>().position,transform.position) <= minDist)
        {
            if(waypointIndex < waypoints.Length)
            {
                waypointIndex++;
                currWaypoint = waypoints[waypointIndex];
            }
            else
            {
                //notify controller than enemy made it through;

            }
        }
        
        transform.up = currWaypoint.GetComponent<Transform>().position - transform.position;
        rb.velocity = transform.up * speed * Time.smoothDeltaTime;

       // Vector3 dir = currWaypoint.GetComponent<Transform>().position - transform.position;
        //Debug.Log("x: " + dir.x + " y: " + dir.y + " z: " + dir.z);



        //  transform.Translate(speed * Time.deltaTime * dir);
        //  transform.localPosition = (speed * Time.deltaTime * dir);
        //  Debug.Log("speed: " + speed + " time: " + Time.deltaTime);

       //  transform.Translate(currWaypoint.GetComponent<Transform>().position * speed * Time.deltaTime, Camera.main.transform);
        Debug.Log("x: " + transform.position.x + " y: " + transform.position.y + " z: " + transform.position.z);
    }

   // private void PointAtPosition(Vector3 p, float r)
   // {
   //     Vector3 v = p - transform.position;
   //     transform.up = v;
   // }


}
