using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    public float speed = 0.4f; 

    private Rigidbody playerRb;

    
    private void Start()
    { 
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    void FixedUpdate()
    {
        float xDirection = Input.GetAxis("Horizontal"); 
        float zDirection = Input.GetAxis("Vertical"); 
        Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);
        transform.position += moveDirection * speed;

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            isOnGround = false;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
    }
}