using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Entity
{

    protected float dealDamage = 5f;

    Transform player;
    Vector3 direction = new Vector3();
    Vector3 playerPosition;


    // Get Methods
    public float GetDamage() { return dealDamage; }

    // start and update methods
    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }
    void Update()
    {
        if(health <= 0)
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
            print("hit");
            TakeDamage(collision.transform.GetComponent<Damage>().damage);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    private void Move()
    {
        playerPosition = player.position;
        direction = playerPosition - transform.position;
        direction.Normalize();

        transform.GetComponent<Rigidbody2D>().MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }
}
