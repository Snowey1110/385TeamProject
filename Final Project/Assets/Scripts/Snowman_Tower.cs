using System.Collections;
using System.Collections.Generic;
using UnityEditor;
//using UnityEditor.SearchService;
using UnityEngine;

public class Snowman_Tower : MonoBehaviour
{
    // Start is called before the first frame update

    public float towerRange = 5f;
    public float towerFireRate = 3f;
    private float towerNextFire = 0;
   public GameObject targetEnemy;
    private Vector3 currPos;


    void Start()
    {
        //set variables
        currPos = transform.position;
              
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        targetEnemy = getTarget(enemyArray);
        if (targetEnemy != null )
        {
            Debug.Log("targetEnemy found");
            GameObject temp = Instantiate(Resources.Load("Prefabs/marker") as GameObject);
            temp.transform.position = targetEnemy.transform.position;
        }

        //ThrowSnowball(targetEnemy);





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
