using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Sidebar : MonoBehaviour
{
    public string towerName;
    public int upgradeCost;
    public GameController lgamecontroller;
    public Shop lshop;

    // Start is called before the first frame update
    void Start()
    {
        lgamecontroller = FindObjectOfType<GameController>();
        lshop = FindObjectOfType<Shop>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (towerName != "")
        //{
        //    //if (towerName.Contains("Prefabs/")) { }
        //    //else
        //    //{
        //    //    towerName = "Prefabs/" + towerName;
        //    //}

        //    ////set preview picture in sidebar
        //    //Object loadPrefab = Resources.Load(towerName);
        //    //SpriteRenderer spriteFromPrefab = loadPrefab.GetComponent<SpriteRenderer>();
        //    //Sprite sprite = spriteFromPrefab.sprite;
        //    //this.GetComponent<Button>().image.sprite = sprite;

        //    ////set cost
        //    ////string temp = this.GetComponentInChildren<TextMeshPro>().text;
        //    //GetComponentInChildren<TextMeshProUGUI>().text = "Upgrade Cost: $" + upgradeCost;
        //    PreviewTower();
        //}

        
        if (lgamecontroller.selectedTower != null)
        {
            //set working objects
            GameObject towerUpgrade = lgamecontroller.selectedTower;
            String NextUpgrade = lgamecontroller.TowerUpgrade;
            int NextUpgradeCost = lgamecontroller.TowerCost;
            this.GetComponent<Button>().gameObject.SetActive(true);

            //if there is a next upgrade to the tower
            if (NextUpgrade != "")
            {
                //get prefab object
                UnityEngine.Object loadPrefab = Resources.Load("Prefabs/" + NextUpgrade);

                //update sidebar image
                SpriteRenderer spriteFromPrefab = loadPrefab.GetComponent<SpriteRenderer>();
                Sprite sprite = spriteFromPrefab.sprite;
                this.GetComponent<Button>().image.sprite = sprite;

                //update purchase price 
                GetComponentInChildren<TextMeshProUGUI>().text = "Upgrade Cost: $" + NextUpgradeCost;

               // PreviewTower();
            }
            else
            {
                this.GetComponent<Button>().image.sprite = Resources.Load("Prefabs/No").GetComponent<SpriteRenderer>().sprite;
                GetComponentInChildren<TextMeshProUGUI>().text = "No Upgrade Available";


            }

        }
        else
        {
             this.GetComponent<Button>().image.sprite = Resources.Load("Prefabs/No").GetComponent<SpriteRenderer>().sprite;
            //this.GetComponent<Button>().gameObject.SetActive(false);
            
            //GetComponentInChildren<TextMeshProUGUI>().text = "No Upgrade Available";
            GetComponentInChildren<TextMeshProUGUI>().text = "";

        }




    }

    public void UpgradeTower()
    {


        if (lgamecontroller.TowerUpgrade != "")
        {
            if (lshop.GetBalance() >= lgamecontroller.TowerCost)
            {
                GameObject e = Instantiate(Resources.Load("Prefabs/" + lgamecontroller.TowerUpgrade) as GameObject);
                e.transform.position = lgamecontroller.selectedTower.transform.position;
                Destroy(lgamecontroller.selectedTower);
                lshop.subFromBalance(lgamecontroller.TowerCost);
            }
        }

            

        
    }

    //public void PreviewTower()
    //{
    //    //if (towerName.Contains("Prefabs/")) { }
    //    //else
    //    //{
    //    //    towerName = "Prefabs/" + towerName;
    //    //}

    //    ////set preview picture in sidebar
    //    //Object loadPrefab = Resources.Load(towerName);
    //    //SpriteRenderer spriteFromPrefab = loadPrefab.GetComponent<SpriteRenderer>();
    //    //Sprite sprite = spriteFromPrefab.sprite;
    //    //this.GetComponent<Button>().image.sprite = sprite;

    //    ////set cost
    //    ////string temp = this.GetComponentInChildren<TextMeshPro>().text;
    //    //GetComponentInChildren<TextMeshProUGUI>().text = "Upgrade Cost: $" + upgradeCost;
    //}


}