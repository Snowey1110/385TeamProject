using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noPlace : MonoBehaviour
{
    public bool isMouseOver = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool getMouseOver()
    {
        return isMouseOver;
    }
    private void OnMouseOver()
    {
        //Debug.Log(this.gameObject.name + " " + isMouseOver);
        isMouseOver = true;
    }

    private void OnMouseExit()
    {
        isMouseOver = false;
    }

    





}
