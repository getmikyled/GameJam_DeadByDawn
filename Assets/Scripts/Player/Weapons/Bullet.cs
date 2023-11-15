using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float bulletSpeed = 2f;
    Boolean shooting = false;

    private void Update()
    {
        if(shooting)
        {
            transform.Translate(transform.up * bulletSpeed * Time.deltaTime, Space.World);
        }
    }

    public void Fire(Vector3 direction) 
    {
        transform.up = direction;
        gameObject.SetActive(true);
        shooting = true;

        StartCoroutine(HideBullet());
    }

    private IEnumerator HideBullet()
    {
        yield return new WaitForSeconds(3);
        shooting = false;
        gameObject.SetActive(false);
    }
}
