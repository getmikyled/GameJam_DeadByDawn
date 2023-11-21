using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected float speed;
    
    public float GetHealth () { return health; }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
