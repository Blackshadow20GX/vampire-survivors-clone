using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement
    public float moveSpeed;
    Rigidbody2D rb;

    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;
    [HideInInspector]
    public Vector2 moveDir;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        InputManagement();
    }

    public bool IsMovingRight()
    {
        return moveDir.x > 0;
    }

    public bool IsMovingLeft()
    {
        return moveDir.x < 0;
    }

    public bool IsMovingUp()
    {
        return moveDir.y > 0;
    }

    public bool IsMovingDown()
    {
        return moveDir.y < 0;
    }

    public bool IsMoving()
    {
        return moveDir.x != 0 || moveDir.y != 0;
    }

    public bool IsMovingVertically()
    {
        return moveDir.y != 0;
    }

    public bool IsMovingHorizontally()
    {
        return moveDir.x != 0;
    }

    public bool IsIdle()
    {
        return !IsMoving();
    }

    void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;

        // Apparently fixes bug when moving up -> faces right automatically when facing left,
        // but I don't get this bug. Might be I wrote conditions differently.
        /**
        if(moveDir.x != 0)
        {
            lastHorizontalVector = moveDir.x;
        }
        if(moveDir.y != 0)
        {
            lastVerticalVector = moveDir.y;
        }**/
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }
}
