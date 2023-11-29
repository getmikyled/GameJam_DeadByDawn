using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveObject : MonoBehaviour
{
    Transform objectiveUI;

    private void Start()
    {
        objectiveUI = GameObject.Find("UI Interface").transform.Find("Objectives");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            objectiveUI.transform.GetComponent<Objective>().CompletedTask(1);
        }
    }
}
