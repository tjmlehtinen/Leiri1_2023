using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D body;
    // input
    private float horizontalMovement;

    // moving
    private float moveSpeed = 5f;
    private Vector2 movement = new Vector2();

    // jumping
    public float jumpForce = 1f;

    // animation
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        //Debug.Log(horizontalMovement);
        movement.x = horizontalMovement * moveSpeed;

        // animation
        animator.SetFloat("speed", Mathf.Abs(horizontalMovement));
    }

    void FixedUpdate()
    {
        // moving
        transform.Translate(movement * Time.deltaTime);

        // jumping
        if (Input.GetButton("Jump"))
        {
            body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
