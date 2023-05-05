using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseBahavior : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    public HealthBarBehavior healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        GameState();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enemy Breached!");
        Destroy(collision.gameObject);

        currentHealth -= 2;
        healthBar.SetHealth(currentHealth);
    }

    private void GameState()
    {
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
