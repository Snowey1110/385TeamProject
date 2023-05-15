using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medic_Tower : MonoBehaviour
{
    private GameController lgamecontroller;

    public float towerRange = 2f;
    public float healRate = 2f;

    private float maxHealth = 100f;
    public float towerHealth = 0f;

    private Vector3 currPos;

    public String NextUpgrade;
    public int NextUpgradeCost;
    //private bool selected = false;

    //healthbar variable
    private HealthBarStatic healthBar;

    void Start()
    {
        lgamecontroller = FindObjectOfType<GameController>();

        NextUpgrade = "";
        NextUpgradeCost = 0;

        towerHealth = maxHealth;
        currPos = transform.position;
        HealingCircle();

        //finds the healthbar script
        healthBar = FindObjectOfType<HealthBarStatic>();

        //sets the healthbar to full
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        Heal();
        healthBar.SetHealth(towerHealth);

        if ((lgamecontroller.selectedTower == this.gameObject) && Input.GetKeyDown(KeyCode.Delete))
        {
            Destroy(gameObject);
        }
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

        Flash tmp = this.gameObject.GetComponent<Flash>();
        tmp.hit();

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

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //lgamecontroller = GetComponent<GameController>();

            //if no tower is selcted
            if (lgamecontroller.selectedTower == null)
            {
                //set gamecontroller to tower
                lgamecontroller.selectedTower = this.gameObject;
                lgamecontroller.TowerUpgrade = NextUpgrade;
                lgamecontroller.TowerCost = NextUpgradeCost;

                //highlight tower
                this.GetComponent<SpriteRenderer>().color = new Color(1f, 0.79f, 0.58f, 1f);
            }

            //if a different tower is selected
            else if (this.gameObject != lgamecontroller.selectedTower)
            {
                //get current selected tower
                GameObject temp = lgamecontroller.selectedTower;
                //remove highlight
                temp.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                //set selected tower to this tower
                lgamecontroller.selectedTower = this.gameObject;
                lgamecontroller.TowerUpgrade = NextUpgrade;
                lgamecontroller.TowerCost = NextUpgradeCost;

                //highlight tower
                this.GetComponent<SpriteRenderer>().color = new Color(1f, 0.79f, 0.58f, 1f);
            }

            //is this tower is selected
            else
            {
                //set selected tower to null
                lgamecontroller.selectedTower = null;
                lgamecontroller.TowerUpgrade = "";
                lgamecontroller.TowerCost = 0;

                //remove highlight
                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            }
        }
    }




}
