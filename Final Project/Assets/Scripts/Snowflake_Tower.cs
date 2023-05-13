using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Snowflake_Tower : MonoBehaviour
{
    public float towerRange = 3f;
    public float towerFireRate = 3f;

    private float maxHealth = 100f;
    public float towerHealth = 0f;

    public GameObject targetEnemy;
    public String NextUpgrade;
    public int NextUpgradeCost;

    private float towerNextFire = 0;
    private Vector3 currPos;
    private bool selected = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Heal(float amount)
    {
        if (towerHealth <= maxHealth)
        {
            towerHealth += amount;
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
