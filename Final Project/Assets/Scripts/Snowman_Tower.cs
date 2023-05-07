using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class Snowman_Tower : MonoBehaviour
{
    // Start is called before the first frame update

    public float towerRange = 3f;
    public float towerFireRate = 3f;
    public GameObject targetEnemy;
    public String NextUpgrade;
    public int NextUpgradeCost;

    private float towerNextFire = 0;
    private Vector3 currPos;
    private bool selected = false;


    void Start()
    {
        //set variables
        currPos = transform.position;
        if(this.name == "Snowman_Tower")
        {
            NextUpgrade = "Snowman_Tower1";
            NextUpgradeCost = 400;
        }
        else if(this.name == "Snowman_Tower1")
        {
            NextUpgrade = null;
        }
              
    }

    // Update is called once per frame
    void Update()
    {
        //deselect tower after mouse over event
        if(Input.GetMouseButtonDown(0))
        {
            if (selected)
            {
                selected = false;
                this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            }
        }

        //get list of all enemies and then find closest one
        GameObject[] enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        targetEnemy = getTarget(enemyArray);
        //if (targetEnemy != null )
        //{
        //    Debug.Log("targetEnemy found");
        //    GameObject temp = Instantiate(Resources.Load("Prefabs/marker") as GameObject);
        //    temp.transform.position = targetEnemy.transform.position;
        //}

        ThrowSnowball(targetEnemy);

    }

    private void OnMouseOver()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1f, 0.79f, 0.58f, 1f);
            Sidebar temp = FindObjectOfType<Sidebar>();
            temp.towerName = NextUpgrade;
            temp.upgradeCost = NextUpgradeCost;
        }
    }
    private void OnMouseExit()
    {
        selected = true;
    }



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

}
