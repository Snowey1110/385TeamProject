using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeCircle : MonoBehaviour
{
    private float radius;
    private Color color;
    private Snowman_Tower tower;
    public bool showRadius = false;




    // Start is called before the first frame update
    void Start()
    {
        //get radius of specified tower
        tower = this.GetComponentInParent<Snowman_Tower>();
        
        // center range circle on tower
        this.transform.position = tower.transform.position;

        //set color of range circle
        color = new Color(0.22f, 1, 0.07f, 0.29f);
        this.GetComponent<SpriteRenderer>().color = color;

        //set size of circle
        float towerScale = tower.towerRange / (tower.transform.localScale.x / 2);

        Debug.Log("towerScale " + towerScale + "range " + tower.towerRange);
        this.transform.localScale = new Vector3(towerScale, towerScale, 1);

        this.GetComponent<SpriteRenderer>().enabled = false;

        

    }

    // Update is called once per frame
    void Update()
    {
        //get radius of specified tower
        radius = this.GetComponentInParent<Snowman_Tower>().towerRange;
        
        // center range circle on tower
        this.transform.position = tower.transform.position;


        if (Input.GetKeyDown(KeyCode.P))
        {
            if(showRadius)
            {
                showRadius = false;
                this.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                showRadius = true;
                this.GetComponent<SpriteRenderer>().enabled = true;
            }
        }



    }
}
