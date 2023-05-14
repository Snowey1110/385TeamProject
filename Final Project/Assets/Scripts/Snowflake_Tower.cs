using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Snowflake_Tower : MonoBehaviour
{
    public float towerRange = 2f;

    private float maxHealth = 100f;
    public float towerHealth = 0f;

    public String NextUpgrade;
    public int NextUpgradeCost;

    private float towerNextFire = 0;
    private Vector3 currPos;
    private bool selected = false;

    private HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        towerHealth = maxHealth;
        currPos = transform.position;

        //finds the healthbar script
        healthBar = FindObjectOfType<HealthBar>();

        //sets the healthbar to full
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        Freeze();
    }

    void Freeze()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, towerRange);

        foreach (Collider2D hitCollider in hitColliders)
        {
            Egg_Enemy enemy = hitCollider.GetComponent<Egg_Enemy>();
            if (enemy != null)
            {
                float dist = Vector3.Distance(enemy.transform.position, currPos);
                if (dist < towerRange)
                {
                    enemy.Freeze(Time.time);
                }
            }
        }
    }

    public void Heal(float amount)
    {
        if (towerHealth <= maxHealth)
        {
            towerHealth += amount;

            //update the healthbar
            healthBar.SetHealth(towerHealth);
        }
    }

    public void Hit(float amount)
    {
        towerHealth -= amount;

        //update the healthbar
        healthBar.SetHealth(towerHealth);

        if (towerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
