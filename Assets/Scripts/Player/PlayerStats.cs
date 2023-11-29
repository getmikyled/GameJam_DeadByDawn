using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    [SerializeField] float health = 3f;

    [SerializeField] Transform heartsParent;
    Transform[] hearts;
    [SerializeField] Sprite heartSprite;
    [SerializeField] Sprite deadHeartSprite;

    [SerializeField] AudioClip hurtSound;
    [Range(0f, 100f)]
    [SerializeField] float volume = 0.5f;

    private void Start()
    {
        hearts = new Transform[heartsParent.childCount];
        for (int heart = 0; heart < heartsParent.childCount; heart++)
        {
            hearts[heart] = heartsParent.GetChild(heart);
        }
    }

    public void TakeDamage(float damage)
    { 
        try
        {
            hearts[(int)health - 1].GetComponent<Image>().sprite = deadHeartSprite;
            health -= damage;
            AudioManager.audioManager.PlayAudio(hurtSound, transform, volume);

            if (health == 0)
            {
                GameObject.Find("UI Interface").transform.Find("YouLose").gameObject.SetActive(true);
            }
        }
        catch (IndexOutOfRangeException)
        {

        }
    }
    
}
