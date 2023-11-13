using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] protected float damage = 10f;
    [SerializeField] protected float bulletSpeed = 2f;
    Boolean shooting = false;

    public void Fire(Vector3 direction) 
    {
        transform.up = direction;
        gameObject.SetActive(true);
        shooting = true;

        while (shooting)
        {
            transform.Translate(direction * bulletSpeed * Time.deltaTime, Space.World);
            HideBullet();
        }
    }

    private void HideBullet()
    {
        if (!GetComponent<Renderer>().isVisible)
        {
            shooting = false;
        }
    }
}