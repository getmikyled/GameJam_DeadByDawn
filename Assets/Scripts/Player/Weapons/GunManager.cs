using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunManager : MonoBehaviour
{

    Transform player;
    Transform[] bulletArray;

    Boolean gunActive = true;
    protected int ammoCount;
    int bulletID = 0;
    Transform currentBullet;

    protected virtual void Gun()
    {
        ammoCount = 10;
    }

    // Start is called before the first frame update
    void Start()
    {
        FindBullets();
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (gunActive)
        {
            FireBullet();
        }
    }

    void FindBullets()
    {
        bulletArray = new Transform[transform.childCount];
        for (int bullet = 0; bullet < bulletArray.Length; bullet++)
        {
            bulletArray[bullet] = transform.GetChild(bullet);
        }
    }

    void FireBullet()
    {
        if (Input.GetMouseButtonDown(0)) {
            currentBullet = bulletArray[bulletID];
            bulletID++;
            currentBullet.GetComponent<Bullet>().Fire(player.up);
            currentBullet.position = player.position;
        }
    }
}
