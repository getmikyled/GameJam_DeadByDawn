using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishObjective : MonoBehaviour
{
    Transform objectiveUI;
    Objective objectivesUIScript;

    private void Start()
    {
        objectiveUI = GameObject.Find("UI Interface").transform.Find("Objectives");
        objectivesUIScript = objectiveUI.GetComponent<Objective>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (objectivesUIScript.taskOneCompleted) {
            if (collision.CompareTag("Player"))
            {
                Debug.Log("Finished Game");
                SceneManager.LoadScene("EndScene");
            }
        }
    }
}
