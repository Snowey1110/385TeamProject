using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    public float damage = 50f;
    public GameObject target;
    private Vector3 targetDirection;

    //update the number of enemies killed
    private WaveSpawner wavespawner;
    private GameController lgamecontroller;
    private Egg_Enemy enemyscript;

    void Start()
    {
        //access the wavespawner.cs script
        wavespawner = FindObjectOfType<WaveSpawner>();
        lgamecontroller = FindObjectOfType<GameController>();

        AquireTarget();
    }

    void Update()
    {
        TrackTarget();
    }

    void AquireTarget()
    {
        // Find the closest enemy
        //GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //float minDistance = Mathf.Infinity;
        //foreach (GameObject enemy in enemies)
        //{
        //    float distance = Vector3.Distance(transform.position, enemy.transform.position);
        //    if (distance < minDistance)
        //    {
        //        minDistance = distance;
        //        target = enemy;
        //    }
        //}

        // Set the target direction to the closest enemy
        if (target != null)
        {
            targetDirection = (target.transform.position - transform.position).normalized;
        }
    }

    void TrackTarget()
    {
        if (target != null)
        {
            // Update the target direction as the target moves
            targetDirection = (target.transform.position - transform.position).normalized;

            // Rotate the bullet to face the target
            float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

            // Move the bullet towards the target direction
            transform.position += targetDirection * speed * Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //update the number of killed enemies to progress the round/difficulty
            //wavespawner.UpdateKilledEnemies(); 

            //Destroy(collision.gameObject);
            //do damage to the enemy
            enemyscript = collision.gameObject.GetComponent<Egg_Enemy>();
            enemyscript.DamageEnemy(damage);

            //destroy's the snowball bullet itself
            Destroy(gameObject);           
        }
    }
}