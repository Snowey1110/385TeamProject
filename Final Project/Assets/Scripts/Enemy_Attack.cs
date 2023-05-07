using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    public GameObject bullet;
    //public Transform bulletPos;

    //private float timer;
    //private GameObject target;


    private GameObject targetTower;
    private float nextFire = 0;

    public float fireRate;
    public float enemyRange;

    // Start is called before the first frame update
    void Start()
    {
        //acquire the tower
        //target = GameObject.FindGameObjectWithTag("Tower");
    }

    // Update is called once per frame
    void Update()
    {
        //get array of all closest enemies
        GameObject[] towerArray = GameObject.FindGameObjectsWithTag("Tower");
        targetTower = closestTarget(towerArray);

        Shoot(targetTower);
        /* float distance = Vector2.Distance(transform.position, target.transform.position);

        if(distance < 5)
        {
            //sets the firerate
            timer += Time.deltaTime;

            if(timer > 2)
            {
                timer = 0;
                Shoot();
            }
        } */
    }

    private GameObject closestTarget(GameObject[] towers)
    {
        //declare empty gameobject
        GameObject closest_tower = null;

        //set the distance first to an infinite value
        float smallestDistance = Mathf.Infinity;

        //iterate through the array of objects, find the tower that is closest to the enemy
        foreach(GameObject tower in towers)
        {
            //find distance between character and particular enemy
            float distanceToTower = (tower.transform.position - this.transform.position).sqrMagnitude;

            //only considers enemies that are within the range of the enemy
            if(distanceToTower < enemyRange)
            {
                //compare the distance of the current tower in the array with the smallest distance so far
                if(distanceToTower < smallestDistance)
                {
                    //set smallest distance to smallest distance
                    smallestDistance = distanceToTower;

                    //set the tower to the tower variable to return
                    closest_tower = tower;
                }
            }
        }

        return closest_tower;
    }

    void Shoot(GameObject tower_target)
    {
        //if a null target is passed in (meaning no towers are in range) do not execute
        if(tower_target != null)
        {
            if(Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;

                //instantiate the stinger/bullet
                GameObject stinger = Instantiate(Resources.Load("Prefabs/Stinger") as GameObject);
                
                stinger.transform.localPosition = transform.localPosition;

                stinger.transform.rotation = transform.rotation;

                //access the stinger to set the tower to be the public variable target in enemy bullet script
                stinger.GetComponent<EnemyBullet>().target = tower_target;
            }
        }
        //create the bullet/stinger
        //Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
