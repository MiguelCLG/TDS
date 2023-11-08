using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] int damage = 100;
    [SerializeField] int coinCount = 100;

    bool attacking = false;
    Transform playerTransform;
    Animator animator;
    void Start()
    {
        playerTransform = FindObjectOfType<Hero>().transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(!attacking)
        {
            Move();

        }
    }

    private void Move()
    {
        float AngleRad = Mathf.Atan2(playerTransform.position.y - transform.position.y, playerTransform.position.x - transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
    }

    public void Attack()
    {
        if (!attacking)
        {
            animator.SetBool("Attacking", false);
        }
        HealthManagement playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthManagement>();
        playerHealth.TakeDamage(damage);
    }

    public int GetCoins() { return coinCount; }

    private void OnTriggerStay2D(Collider2D collision)
    {
        CheckCollision(collision);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        attacking = false;
    }

    private void CheckCollision(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            attacking = true;
            animator.SetBool("Attacking", true);
        }
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckCollision(collision);
    }
 
}
