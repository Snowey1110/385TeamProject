using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject target;
    private Rigidbody2D rb;

    //control speed of bullet in editor
    public float force;
    private float damage = 2f;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //target = GameObject.FindGameObjectWithTag("Tower"); //might have to change to findgameobjectS

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
        if (other.gameObject.CompareTag("Tower"))
        {
            Destroy(gameObject);

            if (other.gameObject.name == "Snowman_Tower(Clone)")
            {
                Snowman_Tower smt = other.gameObject.GetComponent<Snowman_Tower>();
                smt.Hit(damage);
            }
            if (other.gameObject.name == "TowerB(Clone)")
            {
                Medic_Tower mt = other.gameObject.GetComponent<Medic_Tower>();
                mt.Hit(damage);
            }
            if (other.gameObject.name == "TowerC(Clone)")
            {
                Snowflake_Tower sft = other.gameObject.GetComponent<Snowflake_Tower>();
                sft.Hit(damage);
            }
        }
    }
}
