using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Entity
{

    protected float dealDamage = 5f;

    // Get Methods
    public float GetDamage() { return dealDamage; }

    // start and update methods
    private void Start()
    {
        health = 20f;
    }
    void Update()
    {
        if(health <= 0)
        {
            Kill();
        }
    }

    // On collision activity
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.transform.name + "Detected");
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
}
