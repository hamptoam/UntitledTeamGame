using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.43f;
    public Rigidbody rb;
    public bool PlayerIsOnTheGround = true;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    // Start is called before the first frame update
    private void Start()
    {
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        rb = GetComponent<Rigidbody>();
    }

    //movement
    void Update()
    {
        Debug.Log(PlayerIsOnTheGround);
        float xDirection = Input.GetAxis("Horizontal"); //left, right
        float zDirection = Input.GetAxis("Vertical"); //Back, forward. In unity z is up and down
        Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);
        transform.position += moveDirection * speed;
    }
    //Jump
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && PlayerIsOnTheGround)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            PlayerIsOnTheGround = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            PlayerIsOnTheGround = true;
        }
    }
}