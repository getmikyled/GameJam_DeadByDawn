using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected float health;
    
    public float GetHealth () { return health; }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
