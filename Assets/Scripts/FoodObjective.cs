using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodObjective : MonoBehaviour
{
    Transform objectiveUI;
    [SerializeField] Sprite cookiePlayerSprite;

    private void Start()
    {
        objectiveUI = GameObject.Find("UI Interface").transform.Find("Objectives");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            objectiveUI.transform.GetComponent<Objective>().CompletedTask(1);
            gameObject.SetActive(false);
            collision.transform.GetComponent<SpriteRenderer>().sprite = cookiePlayerSprite;
        }
    }
}
