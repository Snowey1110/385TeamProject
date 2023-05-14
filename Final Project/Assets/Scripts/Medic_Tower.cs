using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medic_Tower : MonoBehaviour
{
    public float towerRange = 4f;
    public float healRate = 3f;

    private float maxHealth = 100f;
    public float towerHealth = 0f;

    private Vector3 currPos;
    private bool selected = false;

    //healthbar variable
    private HealthBar healthBar;

    void Start()
    {
        towerHealth = maxHealth;
        currPos = transform.position;
        HealingCircle();

        //finds the healthbar script
        healthBar = FindObjectOfType<HealthBar>();

        //sets the healthbar to full
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        Heal();
        healthBar.SetHealth(towerHealth);
    }

    //function to handle healing other towers
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

            Medic_Tower mt = hitCollider.GetComponent<Medic_Tower>();
            if (mt != null)
            {
                mt.Heal(healRate * Time.deltaTime);
            }

            Snowflake_Tower sft = hitCollider.GetComponent<Snowflake_Tower>();
            if (sft != null)
            {
                sft.Heal(healRate * Time.deltaTime);
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
    // TODO Implement a circle around tower to show tower healing.
    public void HealingCircle()
    {
        GameObject healingCircle = Instantiate(Resources.Load("Prefabs/Radius") as GameObject, currPos, Quaternion.identity);
        healingCircle.transform.localScale = new Vector3(towerRange * 2f, towerRange * 2f, 1f);
        SpriteRenderer renderer = healingCircle.GetComponent<SpriteRenderer>();
        renderer.color = new Color(0f, 1f, 0.8f, 0.25f);
    }

    //function to handle receiving healing
    public void Heal(float amount)
    {
        if (towerHealth <= maxHealth)
        {
            towerHealth += amount;
        }
    }
}
