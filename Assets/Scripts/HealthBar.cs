using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    [SerializeField] float barDisplay; //current progress
    [SerializeField] Slider healthBar;
    GameObject player;
    HealthManagement playerHealth;

    private void Start()
    {
        player = FindObjectOfType<Hero>().gameObject;
        playerHealth = player.GetComponent<HealthManagement>();
        healthBar = GetComponent<Slider>();
        GetPlayerHealth();
    }

    private void UpdateHealth() { healthBar.value = barDisplay; }
    private void Update()
    {
        GetPlayerHealth();
    }

    private void GetPlayerHealth()
    {
        barDisplay = playerHealth.GetHealth();
        UpdateHealth();
    }
}
