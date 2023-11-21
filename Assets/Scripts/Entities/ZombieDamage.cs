using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDamage : Damage
{

    Boolean damaged = false;

    // Start is called before the first frame update
    void Start()
    {
        damage = 1f;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !damaged)
        {
            damaged = true;
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
            StartCoroutine(DamageTimer(2));
        }
    }

    protected IEnumerator DamageTimer(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        damaged = false;
    }
}
