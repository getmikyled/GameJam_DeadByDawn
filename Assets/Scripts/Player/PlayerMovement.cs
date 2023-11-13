using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Transform player;

    float horizontalInput;
    float verticalInput;
    Vector2 direction = new Vector2();

    Vector3 mousePos;
    Vector2 rotationDirection = new Vector2();

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
        RotatePlayer();
    }

    void MovePlayer()
    {
        //establish direction based on player input
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        direction = new Vector2(horizontalInput, verticalInput);
        direction.Normalize();

        player.Translate(direction * Time.deltaTime * speed, Space.World);
    }

    void RotatePlayer()
    {
        //points character towards mouse position
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        rotationDirection.Set(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.up = rotationDirection;
    }
}