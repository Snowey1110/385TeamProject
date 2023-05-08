using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowflake_Tower : MonoBehaviour
{
    public float towerRange = 3f;
    public float healRate = 2f;

    private float maxHealth = 100f;
    public float towerHealth = 0f;

    private Vector3 currPos;
    private bool selected = false;

    // Add these variables for the range circle
    private GameObject rangeCircle;
    private CircleCollider2D rangeCollider;
    public Material rangeMaterial;

    void Start()
    {
        towerHealth = maxHealth;
        currPos = transform.position;

        // Create the range circle game object and set up its components
        rangeCircle = new GameObject("Range Circle");
        rangeCircle.transform.position = transform.position;
        rangeCircle.transform.parent = transform; // make the circle a child of the tower
        rangeCollider = rangeCircle.AddComponent<CircleCollider2D>();
        rangeCollider.radius = towerRange;
        rangeCircle.layer = LayerMask.NameToLayer("Ignore Raycast"); // prevent raycasts from hitting the range circle
        rangeCircle.AddComponent<SpriteRenderer>().material = rangeMaterial;
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
