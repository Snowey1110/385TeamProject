using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    
    private Text textComponent;
    private int balance = 1000;
    private char turret = ' ';

    public Button buttonA;
    public Button buttonB;
    public Button buttonC;
    public Button buttonD;
    public Button buttonE;
    public Button buttonF;

    private int costA = 200;
    private int costB = 250;
    private int costC = 500;
    private int costD = 200;
    private int costE = 250;
    private int costF = 500;

    private void Start()
    {
        textComponent = GameObject.Find("Money").GetComponent<Text>();
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
                    Instantiate(turretA, Pos, Quaternion.identity);
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
        textComponent.text = string.Format("${0}", balance);
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
        spriteRenderer.sortingOrder = 1;
        turretPreview.transform.localScale = turretA.transform.localScale;

        // Add a translucent circle
        SpriteRenderer circleRenderer = circlePrefab.GetComponent<SpriteRenderer>();
        circlePreview = new GameObject("Radius");
        SpriteRenderer radiusRenderer = circlePreview.AddComponent<SpriteRenderer>();
        radiusRenderer.sprite = circleRenderer.sprite;
        radiusRenderer.color = new Color(circleRenderer.color.r, circleRenderer.color.g, circleRenderer.color.b, 0.5f);
        radiusRenderer.sortingOrder = 0;
        circlePreview.transform.localPosition = Vector3.zero;
        circlePreview.transform.parent = turretPreview.transform;
        circlePreview.transform.localScale = Vector3.one * 50f;
    }

    void CreateTurretB()
    {
        SpriteRenderer turretSpriteRenderer = turretB.GetComponent<SpriteRenderer>();
        turretPreview = new GameObject("Turret Preview B");
        SpriteRenderer spriteRenderer = turretPreview.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = turretSpriteRenderer.sprite;
        spriteRenderer.color = new Color(turretSpriteRenderer.color.r, turretSpriteRenderer.color.g, turretSpriteRenderer.color.b, 0.5f);
        spriteRenderer.sortingOrder = 1;
        turretPreview.transform.localScale = turretB.transform.localScale;

        // Add a translucent circle
        SpriteRenderer circleRenderer = circlePrefab.GetComponent<SpriteRenderer>();
        circlePreview = new GameObject("Radius");
        SpriteRenderer radiusRenderer = circlePreview.AddComponent<SpriteRenderer>();
        radiusRenderer.sprite = circleRenderer.sprite;
        radiusRenderer.color = new Color(circleRenderer.color.r, circleRenderer.color.g, circleRenderer.color.b, 0.5f);
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
        spriteRenderer.sortingOrder = 1;
        turretPreview.transform.localScale = turretC.transform.localScale;

        // Add a translucent circle
        SpriteRenderer circleRenderer = circlePrefab.GetComponent<SpriteRenderer>();
        circlePreview = new GameObject("Radius");
        SpriteRenderer radiusRenderer = circlePreview.AddComponent<SpriteRenderer>();
        radiusRenderer.sprite = circleRenderer.sprite;
        radiusRenderer.color = new Color(circleRenderer.color.r, circleRenderer.color.g, circleRenderer.color.b, 0.5f);
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
        spriteRenderer.sortingOrder = 1;
        turretPreview.transform.localScale = turretC.transform.localScale;

        // Add a translucent circle
        SpriteRenderer circleRenderer = circlePrefab.GetComponent<SpriteRenderer>();
        circlePreview = new GameObject("Radius");
        SpriteRenderer radiusRenderer = circlePreview.AddComponent<SpriteRenderer>();
        radiusRenderer.sprite = circleRenderer.sprite;
        radiusRenderer.color = new Color(circleRenderer.color.r, circleRenderer.color.g, circleRenderer.color.b, 0.5f);
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
        spriteRenderer.sortingOrder = 1;
        turretPreview.transform.localScale = turretC.transform.localScale;

        // Add a translucent circle
        SpriteRenderer circleRenderer = circlePrefab.GetComponent<SpriteRenderer>();
        circlePreview = new GameObject("Radius");
        SpriteRenderer radiusRenderer = circlePreview.AddComponent<SpriteRenderer>();
        radiusRenderer.sprite = circleRenderer.sprite;
        radiusRenderer.color = new Color(circleRenderer.color.r, circleRenderer.color.g, circleRenderer.color.b, 0.5f);
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
        spriteRenderer.sortingOrder = 1;
        turretPreview.transform.localScale = turretC.transform.localScale;

        // Add a translucent circle
        SpriteRenderer circleRenderer = circlePrefab.GetComponent<SpriteRenderer>();
        circlePreview = new GameObject("Radius");
        SpriteRenderer radiusRenderer = circlePreview.AddComponent<SpriteRenderer>();
        radiusRenderer.sprite = circleRenderer.sprite;
        radiusRenderer.color = new Color(circleRenderer.color.r, circleRenderer.color.g, circleRenderer.color.b, 0.5f);
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
}