using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool paused = false;
    float sceneStartDelay = 1f;

    Transform player;

    float horizontalInput;
    float verticalInput;
    Vector3 direction = new Vector2();

    Vector3 mousePos;
    Vector2 rotationDirection = new Vector2();

    [SerializeField] float speed = 10f;

    void AssignVariables()
    {
        player = transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        AssignVariables();
        StartCoroutine(DelayStart());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!paused)
        {
            MovePlayer();
        }
    }

    private void Update()
    {
        RotatePlayer();
    }

    void MovePlayer()
    {
        //establish direction based on player input
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontalInput, verticalInput);
        direction.Normalize();

        player.GetComponent<Rigidbody2D>().MovePosition(player.transform.position + (direction * Time.deltaTime * speed));
    }

    void RotatePlayer()
    {
        //points character towards mouse position
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        rotationDirection.Set(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.up = rotationDirection;
    }

    private IEnumerator DelayStart()
    {
        paused = true;
        yield return new WaitForSeconds(sceneStartDelay);
        paused = false;
    }
}
