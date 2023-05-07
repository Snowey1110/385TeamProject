using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Sidebar : MonoBehaviour
{
    public string towerName;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(towerName != "")
        {

            //towerName = "Prefabs/" + towerName;
         //   Object temp = Resources.Load(towerName);
          //  SpriteRenderer temp2 = temp.GetComponent<SpriteRenderer>();
            //Sprite img = temp2.sprite;
           // Sprite img = Resources.Load(towerName).GetComponent<SpriteRenderer>().sprite;
            //this.GetComponent<Button>().image.sprite = img;
        }
       






    }
}
