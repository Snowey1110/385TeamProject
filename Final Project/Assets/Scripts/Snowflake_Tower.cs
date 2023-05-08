using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowflake_Tower : MonoBehaviour
{
    public float towerRange = 4f;
    public float healRate = 3f;

    private float maxHealth = 100f;
    public float towerHealth = 0f;

    private Vector3 currPos;
    private bool selected = false;

    // Add these variables for the range circle
    private CircleCollider2D rangeCollider;
    public Material rangeMaterial;

    void Start()
    {
        towerHealth = maxHealth;
        currPos = transform.position;
    }

    void Update()
    {
        Heal();
    }

    void Heal()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, towerRange);

        foreach (Collider2D hitCollider in hitColliders)
        {
            Snowman_Tower smt = hitCollider.GetComponent<Snowman_Tower>();
            if (smt != null)
            {
                smt.Heal(healRate * Time.deltaTime);
            }
        }
    }

    public void Hit(float amount)
    {
        towerHealth -= amount;

        if (towerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
