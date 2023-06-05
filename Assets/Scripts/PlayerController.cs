using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // input
    private float horizontalMovement;

    // moving
    private float moveSpeed = 5f;
    private Vector2 movement = new Vector2();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        //Debug.Log(horizontalMovement);
        movement.x = horizontalMovement * moveSpeed;
    }

    void FixedUpdate()
    {
        transform.Translate(movement * Time.deltaTime);
    }
}
