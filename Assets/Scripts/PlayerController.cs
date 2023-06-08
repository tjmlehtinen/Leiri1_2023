using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D body;
    // input
    private float horizontalMovement;
    private float verticalMovement;

    // moving
    private float moveSpeed = 5f;
    private Vector2 movement = new Vector2();

    // jumping
    public float jumpForce = 5f;
    private bool grounded;

    // climbing
    private bool canClimb;
    private bool isClimbing;
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
        // input handling
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
        movement.x = horizontalMovement * moveSpeed;

        // jumping
        if (Input.GetButtonDown("Jump") && grounded)
        {
            body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // climbing
        if (canClimb && verticalMovement != 0)
        {
            isClimbing = true;
        }
        else
        {
            isClimbing = false;
        }
        if (isClimbing)
        {
            body.isKinematic = true;
            movement.y = verticalMovement * moveSpeed;
        }
        else
        {
            body.isKinematic = false;
        }
        // animation
        animator.SetFloat("speed", Mathf.Abs(horizontalMovement));
    }

    void FixedUpdate()
    {
        // moving
        transform.Translate(movement * Time.deltaTime);

    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            grounded = true;
        }
        if (collision.gameObject.CompareTag("Ladder"))
        {
            canClimb = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            grounded = false;
        }
        if (collision.gameObject.CompareTag("Ladder"))
        {
            canClimb = false;
        }
    }
}
