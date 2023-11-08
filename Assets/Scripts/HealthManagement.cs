using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManagement : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] int maxHealth = 300;
    [SerializeField] Canvas canvas;
    public int GetHealth() { return health; }
    public int GetMaxHealth() { return maxHealth; }

    public void AddHealth(int amount) { if((health + amount) > maxHealth) { health = maxHealth; } else { health += amount; } }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        CheckIfEnemy();
        CheckIfPlayer();
    }

    private void CheckIfPlayer()
    {
        if (gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            canvas.gameObject.SetActive(true);
        }
    }
    private void CheckIfEnemy()
    {
        if (gameObject.tag == "Enemy")
        {
            FindObjectOfType<ScoreDisplay>().AddCoins(GetComponent<Enemy>().GetCoins());
            Destroy(gameObject);
        }
    }
}
