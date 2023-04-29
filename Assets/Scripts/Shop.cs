using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject turretPrefab;
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

    private int costA = 200;
    private int costB = 250;
    private int costC = 500;

    private void Start()
    {
        textComponent = GameObject.Find("Text").GetComponent<Text>();
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
                Instantiate(turretPrefab, Pos, Quaternion.identity);
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
            CreateTurretPreview();
            turret = 'A';
        }
    }

    public void OnButtonBClick()
    {
        if (!isPlacingTurret && balance >= costB)
        {
            isPlacingTurret = true;
            CreateTurretPreview();
            turret = 'B';
        }
    }

    public void OnButtonCClick()
    {
        if (!isPlacingTurret && balance >= costC)
        {
            isPlacingTurret = true;
            CreateTurretPreview();
            turret = 'C';
        }
    }

    void CreateTurretPreview()
    {
        SpriteRenderer turretSpriteRenderer = turretPrefab.GetComponent<SpriteRenderer>();
        turretPreview = new GameObject("Turret Preview");
        SpriteRenderer spriteRenderer = turretPreview.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = turretSpriteRenderer.sprite;
        spriteRenderer.color = new Color(turretSpriteRenderer.color.r, turretSpriteRenderer.color.g, turretSpriteRenderer.color.b, 0.5f);
        spriteRenderer.sortingOrder = 1;
        turretPreview.transform.localScale = turretPrefab.transform.localScale;

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
    }
}