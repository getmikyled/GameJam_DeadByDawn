using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GunManager : MonoBehaviour
{

    Transform player;
    Transform[] bulletArray;

    Boolean gunActive = true;
    bool canReload = true;
    bool canShoot = true;

    protected int magAmount;
    int bulletID = 0;

    [Range(0f, 5f)]
    [SerializeField] float fireDelay = 0.5f;

    Transform currentBullet;

    [SerializeField] AudioClip reloadSound;
    [Range(0f, 100f)]
    [SerializeField] float volume = 0.5f;

    TextMeshProUGUI ammoText;
    

    protected virtual void Gun()
    {
        magAmount = 6;
    }

    // Start is called before the first frame update
    void Start()
    {
        Gun();
        FindBullets();
        player = GameObject.Find("Player").transform;

        ammoText = GameObject.Find("UI Interface").transform.Find("AmmoCounter").Find("Text").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gunActive)
        {
            // Resets ID
            ReloadGun();
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
            if (canShoot)
            {
                try
                {
                    currentBullet = bulletArray[bulletID];
                    Debug.Log("Shot bullet " + bulletID + bulletArray[bulletID].name + " / " + bulletArray.Length);
                    bulletID++;
                    if (bulletID > 6)
                    {
                        return;
                    }
                    currentBullet.GetComponent<Bullet>().Fire(player.up);
                    StartCoroutine(FireTimer(fireDelay));
                    currentBullet.position = player.position;
                    ammoText.text = (6 - bulletID).ToString() + "/6";
                }
                catch (IndexOutOfRangeException) { }
            }
        }
    }

    void ReloadGun() {
        {
            if (Input.GetKeyDown(KeyCode.R) && canReload)
            {
                AudioManager.audioManager.PlayAudio(reloadSound, Camera.main.transform, volume);
                canReload = false;
                StartCoroutine(ReloadTimer(reloadSound.length));
                bulletID = 0;
                ammoText.text = (6 - bulletID).ToString() + "/6";
            }
        }
    }

    private IEnumerator ReloadTimer(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        canReload = true;
    }

    private IEnumerator FireTimer(float seconds)
    {
        canShoot = false;
        yield return new WaitForSeconds(0.6f);
        canShoot = true;
    }
}
