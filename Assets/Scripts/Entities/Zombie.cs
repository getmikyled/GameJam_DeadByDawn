using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Entity
{

    protected float damage = 5f;

    private void Start()
    {
        health = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Kill();
        }
    }
    
    public float GetDamage() { return damage; }
}
