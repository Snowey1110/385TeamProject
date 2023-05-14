using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Snowman_Tower : MonoBehaviour
{
    private GameController lgamecontroller;
    public float towerRange = 3f;
    public float towerFireRate = 3f;

    private float maxHealth = 100f;
    public float towerHealth = 0f;

    public GameObject targetEnemy;
    public String NextUpgrade;
    public int NextUpgradeCost;

    private float towerNextFire = 0;
    private Vector3 currPos;
   // private bool selected = false;

    //healthbar scripts
    private HealthBar healthBar;
    void Start()
    {
        lgamecontroller = FindObjectOfType<GameController>();

        //set variables
        currPos = transform.position;

        if(this.name == "Snowman_Tower")
        {
            NextUpgrade = "Snowman_Tower1";
            NextUpgradeCost = 400;
        }
        else if(this.name == "Snowman_Tower1")
        {
            NextUpgrade = "";
            NextUpgradeCost = 0;
        }
        towerHealth = maxHealth;

        //healthbar code
        //get the healthbar script
        healthBar = FindObjectOfType<HealthBar>();

        //set the health bar to max
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
        //get list of all enemies and then find closest one
        GameObject[] enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        targetEnemy = getTarget(enemyArray);
        
        ThrowSnowball(targetEnemy);
        healthBar.SetHealth(towerHealth);
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
            else if(this.gameObject != lgamecontroller.selectedTower) 
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
    //private void OnMouseExit()
    //{
    //    selected = true;
    //}

    private GameObject getTarget(GameObject[] enemies)
    {
        GameObject min = null;
        float smallDist = Mathf.Infinity;
        foreach (GameObject enemy in enemies)
        {
            float dist = Vector3.Distance(enemy.transform.position, currPos);
            if (dist < towerRange) 
            {
                if (dist < smallDist)
                {
                    min = enemy;
                    smallDist = dist;
                }
            }
        }

        return min;
    }

    public void ThrowSnowball(GameObject temp)
    {
        if (temp != null)
        {
            if (Time.time > towerNextFire)
            {
                towerNextFire = Time.time + towerFireRate;
                GameObject snowball = Instantiate(Resources.Load("Prefabs/snowball") as GameObject);
                snowball.transform.localPosition = transform.localPosition;
                snowball.transform.rotation = transform.rotation;
                snowball.GetComponent<SnowballBehaviour>().target = temp;
            }

        }
        
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

        Flash tmp = this.gameObject.GetComponent<Flash>();
        tmp.hit();

        if (towerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    //public void dmgFlash()
    //{
    //    float flashTime = 100f;
    //    GameObject temp = this.gameObject;
    //    Color currColor = temp.GetComponent<SpriteRenderer>().color;
    //    Color flashCol = new Color(1, 0, 0, 1);

    //    while (flashTime >= 0) 
    //    {
    //        temp.GetComponent<SpriteRenderer>().color = flashCol;
    //        flashTime -= Time.deltaTime;
    //        Debug.Log(flashTime);
    //    }

    //    temp.GetComponent<SpriteRenderer>().color = currColor;
    //}

}
