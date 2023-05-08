using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{

    private DateTime time;
    // Start is called before the first frame update
    void Start()
    {
        time = System.DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        DateTime temp = System.DateTime.Now;
        TimeSpan delta = temp - time;

        if (delta.Seconds > 5)
        {
            SceneManager.LoadScene("Game Menu");
        }



       // Debug.Log(delta.Seconds);
    }
}
