using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    [SerializeField] float health = 50f;

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
    
}
