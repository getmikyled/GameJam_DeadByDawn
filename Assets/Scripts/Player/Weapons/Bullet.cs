using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float bulletSpeed = 2f;
    Boolean shooting = false;

    [Range(0f, 100f)]
    [SerializeField] float volume = 0.5f;
    [SerializeField] AudioClip fireSound;

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

        AudioManager.audioManager.PlayAudio(fireSound, transform, volume);

        StartCoroutine(HideBullet());
    }

    private IEnumerator HideBullet()
    {
        yield return new WaitForSeconds(3);
        shooting = false;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Obstructions"))
        {
            shooting = false;
            gameObject.SetActive(false);
        }
    }
}
