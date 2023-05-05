using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;

public class Tower_Behaviour : MonoBehaviour
{
    // Start is called before the first frame update

    public float towerRange = 5f;
    public float towerFireRate = 1f;
    private GameObject targetEnemy;
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
        GameObject temp = getTarget(enemyArray);
        





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


}
