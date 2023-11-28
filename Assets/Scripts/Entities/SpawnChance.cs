using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChance : MonoBehaviour
{
    float min = 0;
    float max = 100;
    [Range(0f, 100f)]
    [SerializeField] float spawnChance = 50f;

    private void Awake()
    {
        if (Random.Range(min, max) <= spawnChance)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
