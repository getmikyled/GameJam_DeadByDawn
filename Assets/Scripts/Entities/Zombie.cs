using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GridBrushBase;

public class Zombie : Entity
{

    protected float dealDamage = 5f;

    Transform player;
    Vector3 direction = new Vector3();
    Vector3 playerPosition;

    Detection zombieDetection;

    // Get Methods
    public float GetDamage() { return dealDamage; }

    // start and update methods
    private void Start()
    {
        player = GameObject.Find("Player").transform;
        zombieDetection = gameObject.GetComponentInChildren<Detection>();
    }
    void Update()
    {
        if (health <= 0)
        {
            Kill();
        }
            Move();

    }

    // On collision activity
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            TakeDamage(collision.transform.GetComponent<Damage>().damage);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    private bool PlayerInRange() {return zombieDetection.detectedPlayer;}

    private void Move()
    {
        if (PlayerInRange())
        {
            playerPosition = player.position;
            direction = playerPosition - transform.position;
            direction.Normalize();

            transform.GetComponent<Rigidbody2D>().MovePosition(transform.position + (direction * speed * Time.deltaTime));
        }
        transform.up = direction;
    }
}
