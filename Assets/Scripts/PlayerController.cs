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
    private bool grounded;

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

        // jumping
        if (Input.GetButtonDown("Jump") && grounded)
        {
            body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
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
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            grounded = false;
        }
    }
}
