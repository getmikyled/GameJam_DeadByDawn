using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
    [SerializeField] Sprite uncheckedBox;
    [SerializeField] Sprite checkedBox;

    Transform taskOne;
    public bool taskOneCompleted = false;
    Transform taskTwo;

    // Start is called before the first frame update
    void Start()
    {
        taskOne = transform.GetChild(0);
        taskTwo = transform.GetChild(1);
    }

    public void CompletedTask(int taskID)
    {
        if (taskID == 1)
        {
            taskOne.Find("Checkbox").GetComponent<Image>().sprite = checkedBox;
            taskOneCompleted = true;
            taskTwo.gameObject.SetActive(true);
        }
    }
}
