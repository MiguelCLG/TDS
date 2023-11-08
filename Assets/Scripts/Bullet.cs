using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int damage = 100;
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] GameObject impactVFX;
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        rb.velocity = transform.right * bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckCollisions(collision);
    }

    private void CheckCollisions(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<HealthManagement>().TakeDamage(damage);
        }
        SpawnVFX(collision);
        Destroy(gameObject);
    }

    private void SpawnVFX(Collider2D collision)
    {
        Quaternion rotation = Quaternion.FromToRotation(collision.transform.position.normalized, Vector3.up);
        GameObject vfx = Instantiate(impactVFX, transform.position, rotation);
        Destroy(vfx, .2f);
    }


}
