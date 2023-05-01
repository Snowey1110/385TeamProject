using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    private GameObject[] tagItems;
    public bool showDebug;

    // Start is called before the first frame update
    void Start()
    {
        //Start map hiding waypoints from player.
        tagItems = GameObject.FindGameObjectsWithTag("waypoints");
        foreach (GameObject tagItem in tagItems)
        {
            tagItem.GetComponent<Renderer>().enabled = false;
        }
        showDebug = false;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (showDebug)
            {
                foreach(GameObject tagItem in tagItems)
                {
                    tagItem.GetComponent<Renderer>().enabled = false;
                }
                showDebug = false;
            }
            else
            {
                foreach (GameObject tagItem in tagItems)
                {
                    tagItem.GetComponent<Renderer>().enabled = true;
                }
                showDebug = true;
            }
        }

    }

    public GameObject[] getWaypoints()
    {
        return tagItems;
    }


}
