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
    public GameObject towerUpgrade;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (towerName != "")
        {
            //if (towerName.Contains("Prefabs/")) { }
            //else
            //{
            //    towerName = "Prefabs/" + towerName;
            //}

            ////set preview picture in sidebar
            //Object loadPrefab = Resources.Load(towerName);
            //SpriteRenderer spriteFromPrefab = loadPrefab.GetComponent<SpriteRenderer>();
            //Sprite sprite = spriteFromPrefab.sprite;
            //this.GetComponent<Button>().image.sprite = sprite;

            ////set cost
            ////string temp = this.GetComponentInChildren<TextMeshPro>().text;
            //GetComponentInChildren<TextMeshProUGUI>().text = "Upgrade Cost: $" + upgradeCost;
            PreviewTower();

        }







    }

    public void UpgradeTower()
    {
        //GameObject e = Instantiate(Resources.Load(towerName) as GameObject);
        //e.transform.position = towerUpgrade.transform.position;
        //Destroy(towerUpgrade);
    }

    public void PreviewTower()
    {
        //if (towerName.Contains("Prefabs/")) { }
        //else
        //{
        //    towerName = "Prefabs/" + towerName;
        //}

        ////set preview picture in sidebar
        //Object loadPrefab = Resources.Load(towerName);
        //SpriteRenderer spriteFromPrefab = loadPrefab.GetComponent<SpriteRenderer>();
        //Sprite sprite = spriteFromPrefab.sprite;
        //this.GetComponent<Button>().image.sprite = sprite;

        ////set cost
        ////string temp = this.GetComponentInChildren<TextMeshPro>().text;
        //GetComponentInChildren<TextMeshProUGUI>().text = "Upgrade Cost: $" + upgradeCost;
    }


}