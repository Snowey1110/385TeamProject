using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
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
        tagItems = sort(tagItems); //sort by numeric in object name
        

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

    private GameObject[] sort(GameObject[] tag)
    {
        //temporary array of size tag.length
        GameObject[] temp = new GameObject[tag.Length];

        //holder of number extracted from object name
        string curVal;

        //reorder array using number as index
        foreach(GameObject tagItem in tag)
        {
            curVal = Regex.Match(tagItem.name, @"\d+").Value;
            temp[int.Parse(curVal)] = tagItem;
        }

        return temp;
    }
}

