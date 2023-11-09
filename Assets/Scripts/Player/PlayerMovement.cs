using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Transform player;

    float horizontalInput;
    float verticalInput;
    Vector2 direction = new Vector2();

    [SerializeField] float speed = 3f;

    void AssignVariables()
    {
        player = transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        AssignVariables();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        //establish direction based on player input
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        direction = new Vector2(horizontalInput, verticalInput);
        direction.Normalize();

        player.Translate(direction * Time.deltaTime * speed);
    }
}
