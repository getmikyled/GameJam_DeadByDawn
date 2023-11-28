using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StaircaseManager : MonoBehaviour
{
    Vector3 teleportSpot;

    private void Start()
    {
        teleportSpot = transform.GetChild(0).position;
    }

    [SerializeField] string scenePath;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(scenePath);
        }
    }
}
