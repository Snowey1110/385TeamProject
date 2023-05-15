using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Flash : MonoBehaviour
{

    
    public float flashTime;
    private float startFlash;
    private UnityEngine.Color flashColor;
    private UnityEngine.Color curColor;
    private bool select;
    // Start is called before the first frame update
    void Start()
    {
        curColor = this.gameObject.GetComponent<SpriteRenderer>().color;
        flashColor =  new UnityEngine.Color(1, 0, 0, 1);
        select = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //if in color flash (ie is red)
        if (select)
        {
            startFlash = startFlash + Time.deltaTime;
            //Debug.Log(startFlash);

            if(startFlash > flashTime)
            {
                setColor(curColor);
                select = false;
            }   
        }
    }

    public void setColor(UnityEngine.Color color)
    {
        GameObject temp = this.gameObject;
        temp.GetComponent<SpriteRenderer>().color = color;
    }
    public void hit()
    {
        if (!select)
        {
            startFlash = 0;
            select = true;
            setColor(flashColor);
        }
    }






}
