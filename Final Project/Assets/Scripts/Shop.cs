using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using static UnityEditor.PlayerSettings;
//using TMPro;

public class Shop : MonoBehaviour
{
    
    public GameObject turretA;
    public GameObject turretB;
    public GameObject turretC;
    public GameObject turretD;
    public GameObject turretE;
    public GameObject turretF;

    private GameObject turretPreview;
    public GameObject circlePrefab;
    private GameObject circlePreview;
    private bool isPlacingTurret = false;

    private Text bank;

    private Text towerAPrice;
    private Text towerBPrice;
    private Text towerCPrice;
    private Text towerDPrice;
    private Text towerEPrice;
    private Text towerFPrice;


    private int balance = 500;
    private char turret = ' ';

    public Button buttonA;
    public Button buttonB;
    public Button buttonC;
    public Button buttonD;
    public Button buttonE;
    public Button buttonF;

    private int costA = 200; //Tower A (Snowman)
    private int costB = 250; //Tower B 
    private int costC = 500; //Tower C 
    private int costD = 1000; //Tower D 
    private int costE = 1000; //Tower E 
    private int costF = 1000; //Tower F 

    private void Start()
    {
        bank = GameObject.Find("Money").GetComponent<Text>();

        towerAPrice = GameObject.Find("CostA").GetComponent<Text>();
        towerAPrice.text = string.Format("${0}", costA);

        towerBPrice = GameObject.Find("CostB").GetComponent<Text>();
        towerBPrice.text = string.Format("${0}", costB);

        towerCPrice = GameObject.Find("CostC").GetComponent<Text>();
        towerCPrice.text = string.Format("${0}", costC);

        towerDPrice = GameObject.Find("CostD").GetComponent<Text>();
        towerDPrice.text = string.Format("${0}", costD);

        towerEPrice = GameObject.Find("CostE").GetComponent<Text>();
        towerEPrice.text = string.Format("${0}", costE);

        towerFPrice = GameObject.Find("CostF").GetComponent<Text>();
        towerFPrice.text = string.Format("${0}", costF);

        //Snowman_Turret
        turretA = Instantiate(Resources.Load("Prefabs/Snowman_Tower") as GameObject);
        turretA.SetActive(false);


    }

    private void Update()
    {
        if (isPlacingTurret)
        {
            Vector3 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Pos.z = 0;

            turretPreview.transform.position = Pos;

            if (Input.GetMouseButtonDown(0))
            {
                if (turret == 'A')
                {
                    turretA = Instantiate(Resources.Load("Prefabs/Snowman_Tower") as GameObject, Pos, Quaternion.identity);
                    


                    Debug.Log("turretA towerRange: " + turretA.GetComponent<Snowman_Tower>().towerRange + " turretA localScale.x: " + turretA.GetComponent<Snowman_Tower>().transform.localScale.x);
                    //Instantiate(turretA, Pos, Quaternion.identity);
                }
                if (turret == 'B')
                {
                    Instantiate(turretB, Pos, Quaternion.identity);
                }
                if (turret == 'C')
                {
                    Instantiate(turretC, Pos, Quaternion.identity);
                }
                if (turret == 'D')
                {
                    Instantiate(turretC, Pos, Quaternion.identity);
                }
                if (turret == 'E')
                {
                    Instantiate(turretC, Pos, Quaternion.identity);
                }
                if (turret == 'F')
                {
                    Instantiate(turretC, Pos, Quaternion.identity);
                }
                Destroy(turretPreview);
                isPlacingTurret = false;
                BuyTurret(turret);
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                Destroy(turretPreview);
                isPlacingTurret = false;
            }
        }
        bank.text = "Money: " + string.Format("${0}", balance);
    }

    public void OnButtonAClick()
    {
        if (!isPlacingTurret && balance >= costA)
        {
            isPlacingTurret = true;
            CreateTurretA();
            turret = 'A';
        }
    }

    public void OnButtonBClick()
    {
        if (!isPlacingTurret && balance >= costB)
        {
            isPlacingTurret = true;
            CreateTurretB();
            turret = 'B';
        }
    }

    public void OnButtonCClick()
    {
        if (!isPlacingTurret && balance >= costC)
        {
            isPlacingTurret = true;
            CreateTurretC();
            turret = 'C';
        }
    }

    public void OnButtonDClick()
    {
        if (!isPlacingTurret && balance >= costD)
        {
            isPlacingTurret = true;
            CreateTurretD();
            turret = 'D';
        }
    }

    public void OnButtonEClick()
    {
        if (!isPlacingTurret && balance >= costE)
        {
            isPlacingTurret = true;
            CreateTurretE();
            turret = 'E';
        }
    }

    public void OnButtonFClick()
    {
        if (!isPlacingTurret && balance >= costF)
        {
            isPlacingTurret = true;
            CreateTurretF();
            turret = 'F';
        }
    }


    void CreateTurretA()
    {
        SpriteRenderer turretSpriteRenderer = turretA.GetComponent<SpriteRenderer>();
        turretPreview = new GameObject("Turret Preview A");
        SpriteRenderer spriteRenderer = turretPreview.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = turretSpriteRenderer.sprite;
        spriteRenderer.color = new Color(turretSpriteRenderer.color.r, turretSpriteRenderer.color.g, turretSpriteRenderer.color.b, 0.5f);
        spriteRenderer.sortingLayerName = "Tower";
        spriteRenderer.sortingOrder = 0;
        turretPreview.transform.localScale = turretA.transform.localScale;



        // Add a translucent circle
        SpriteRenderer circleRenderer = circlePrefab.GetComponent<SpriteRenderer>();
        circlePreview = new GameObject("Radius");
        SpriteRenderer radiusRenderer = circlePreview.AddComponent<SpriteRenderer>();
        radiusRenderer.sprite = circleRenderer.sprite;
        radiusRenderer.color = new Color(circleRenderer.color.r, circleRenderer.color.g, circleRenderer.color.b, 0.5f);
        radiusRenderer.sortingLayerName = "RangeCircle";
        radiusRenderer.sortingOrder = 0;
        circlePreview.transform.localPosition = Vector3.zero;
        circlePreview.transform.parent = turretPreview.transform;

       
        float towerScale = turretA.GetComponent<Snowman_Tower>().towerRange / (turretA.GetComponent<Snowman_Tower>().transform.localScale.x / 2);
        Debug.Log("turretA towerRange: " + turretA.GetComponent<Snowman_Tower>().towerRange + "turretA localScale.x: " + turretA.GetComponent<Snowman_Tower>().transform.localScale.x);
        Debug.Log("towerScale = towerRange / tower localscale / 2: " + towerScale);
        circlePreview.transform.localScale = new Vector3(towerScale, towerScale, 1);
        //circlePreview.transform.localScale = Vector3.one * 50f;
    }

    void CreateTurretB()
    {
        SpriteRenderer turretSpriteRenderer = turretB.GetComponent<SpriteRenderer>();
        turretPreview = new GameObject("Turret Preview B");
        SpriteRenderer spriteRenderer = turretPreview.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = turretSpriteRenderer.sprite;
        spriteRenderer.color = new Color(turretSpriteRenderer.color.r, turretSpriteRenderer.color.g, turretSpriteRenderer.color.b, 0.5f);
        spriteRenderer.sortingLayerName = "Tower";
        spriteRenderer.sortingOrder = 0;
        turretPreview.transform.localScale = turretB.transform.localScale;

        // Add a translucent circle
        SpriteRenderer circleRenderer = circlePrefab.GetComponent<SpriteRenderer>();
        circlePreview = new GameObject("Radius");
        SpriteRenderer radiusRenderer = circlePreview.AddComponent<SpriteRenderer>();
        radiusRenderer.sprite = circleRenderer.sprite;
        radiusRenderer.color = new Color(circleRenderer.color.r, circleRenderer.color.g, circleRenderer.color.b, 0.5f);
        radiusRenderer.sortingLayerName = "RangeCircle";
        radiusRenderer.sortingOrder = 0;
        circlePreview.transform.localPosition = Vector3.zero;
        circlePreview.transform.parent = turretPreview.transform;
        circlePreview.transform.localScale = Vector3.one * 50f;
    }

    void CreateTurretC()
    {
        SpriteRenderer turretSpriteRenderer = turretC.GetComponent<SpriteRenderer>();
        turretPreview = new GameObject("Turret Preview C");
        SpriteRenderer spriteRenderer = turretPreview.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = turretSpriteRenderer.sprite;
        spriteRenderer.color = new Color(turretSpriteRenderer.color.r, turretSpriteRenderer.color.g, turretSpriteRenderer.color.b, 0.5f);
        spriteRenderer.sortingLayerName = "Tower";
        spriteRenderer.sortingOrder = 0;
        turretPreview.transform.localScale = turretC.transform.localScale;

        // Add a translucent circle
        SpriteRenderer circleRenderer = circlePrefab.GetComponent<SpriteRenderer>();
        circlePreview = new GameObject("Radius");
        SpriteRenderer radiusRenderer = circlePreview.AddComponent<SpriteRenderer>();
        radiusRenderer.sprite = circleRenderer.sprite;
        radiusRenderer.color = new Color(circleRenderer.color.r, circleRenderer.color.g, circleRenderer.color.b, 0.5f);
        radiusRenderer.sortingLayerName = "RangeCircle";
        radiusRenderer.sortingOrder = 0;
        circlePreview.transform.localPosition = Vector3.zero;
        circlePreview.transform.parent = turretPreview.transform;
        circlePreview.transform.localScale = Vector3.one * 50f;
    }

    void CreateTurretD()
    {
        SpriteRenderer turretSpriteRenderer = turretD.GetComponent<SpriteRenderer>();
        turretPreview = new GameObject("Turret Preview D");
        SpriteRenderer spriteRenderer = turretPreview.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = turretSpriteRenderer.sprite;
        spriteRenderer.color = new Color(turretSpriteRenderer.color.r, turretSpriteRenderer.color.g, turretSpriteRenderer.color.b, 0.5f);
        spriteRenderer.sortingLayerName = "Tower";
        spriteRenderer.sortingOrder = 0;
        turretPreview.transform.localScale = turretC.transform.localScale;

        // Add a translucent circle
        SpriteRenderer circleRenderer = circlePrefab.GetComponent<SpriteRenderer>();
        circlePreview = new GameObject("Radius");
        SpriteRenderer radiusRenderer = circlePreview.AddComponent<SpriteRenderer>();
        radiusRenderer.sprite = circleRenderer.sprite;
        radiusRenderer.color = new Color(circleRenderer.color.r, circleRenderer.color.g, circleRenderer.color.b, 0.5f);
        radiusRenderer.sortingLayerName = "RangeCircle";
        radiusRenderer.sortingOrder = 0;
        circlePreview.transform.localPosition = Vector3.zero;
        circlePreview.transform.parent = turretPreview.transform;
        circlePreview.transform.localScale = Vector3.one * 50f;
    }

    void CreateTurretE()
    {
        SpriteRenderer turretSpriteRenderer = turretE.GetComponent<SpriteRenderer>();
        turretPreview = new GameObject("Turret Preview E");
        SpriteRenderer spriteRenderer = turretPreview.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = turretSpriteRenderer.sprite;
        spriteRenderer.color = new Color(turretSpriteRenderer.color.r, turretSpriteRenderer.color.g, turretSpriteRenderer.color.b, 0.5f);
        spriteRenderer.sortingLayerName = "Tower";
        spriteRenderer.sortingOrder = 0;
        turretPreview.transform.localScale = turretC.transform.localScale;

        // Add a translucent circle
        SpriteRenderer circleRenderer = circlePrefab.GetComponent<SpriteRenderer>();
        circlePreview = new GameObject("Radius");
        SpriteRenderer radiusRenderer = circlePreview.AddComponent<SpriteRenderer>();
        radiusRenderer.sprite = circleRenderer.sprite;
        radiusRenderer.color = new Color(circleRenderer.color.r, circleRenderer.color.g, circleRenderer.color.b, 0.5f);
        radiusRenderer.sortingLayerName = "RangeCircle";
        radiusRenderer.sortingOrder = 0;
        circlePreview.transform.localPosition = Vector3.zero;
        circlePreview.transform.parent = turretPreview.transform;
        circlePreview.transform.localScale = Vector3.one * 50f;
    }

    void CreateTurretF()
    {
        SpriteRenderer turretSpriteRenderer = turretF.GetComponent<SpriteRenderer>();
        turretPreview = new GameObject("Turret Preview F");
        SpriteRenderer spriteRenderer = turretPreview.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = turretSpriteRenderer.sprite;
        spriteRenderer.color = new Color(turretSpriteRenderer.color.r, turretSpriteRenderer.color.g, turretSpriteRenderer.color.b, 0.5f);
        spriteRenderer.sortingLayerName = "Tower";
        spriteRenderer.sortingOrder = 0;
        turretPreview.transform.localScale = turretC.transform.localScale;

        // Add a translucent circle
        SpriteRenderer circleRenderer = circlePrefab.GetComponent<SpriteRenderer>();
        circlePreview = new GameObject("Radius");
        SpriteRenderer radiusRenderer = circlePreview.AddComponent<SpriteRenderer>();
        radiusRenderer.sprite = circleRenderer.sprite;
        radiusRenderer.color = new Color(circleRenderer.color.r, circleRenderer.color.g, circleRenderer.color.b, 0.5f);
        radiusRenderer.sortingLayerName = "RangeCircle";
        radiusRenderer.sortingOrder = 0;
        circlePreview.transform.localPosition = Vector3.zero;
        circlePreview.transform.parent = turretPreview.transform;
        circlePreview.transform.localScale = Vector3.one * 50f;
    }

    void BuyTurret(char buyTurret)
    {
        if (buyTurret == 'A')
        {
            balance -= costA;
        }

        if (buyTurret == 'B')
        {
            balance -= costB;
        }

        if (buyTurret == 'C')
        {
            balance -= costC;
        }

        if (buyTurret == 'D')
        {
            balance -= costD;
        }

        if (buyTurret == 'E')
        {
            balance -= costE;
        }

        if (buyTurret == 'F')
        {
            balance -= costF;
        }
    }

    //public method to return how much money user has
    public int GetBalance()
    {
        return balance;
    }

    //public method to deposit an amount each time enemy killed or whatever else
    public void BalanceDeposit(int deposit)
    {
        balance += deposit;
    }
}