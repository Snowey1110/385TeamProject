using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject target;
    private Rigidbody2D rb;

    //control speed of bullet in editor
    public float force;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Tower"); //might have to change to findgameobjectS

        Vector3 direction = target.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        //rotates stinger so it faces the direction its going
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 10)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Tower"))
        {
            Destroy(gameObject);
        }
    }
}
