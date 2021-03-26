using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.43f;
    public Rigidbody rb;
    public bool PlayerIsOnTheGround = true;
    private void Start()

    // Start is called before the first frame update
    void Start()
   
    {
        rb = GetComponent<Rigidbody>();
    }

    //movement
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal"); //left, right
        float zDirection = Input.GetAxis("Vertical"); //Back, forward. In unity z is up and down
        Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);
        transform.position += moveDirection * speed;
    }

    //Jump
    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump") && PlayerIsOnTheGround)
        {
            rb.AddForce(new Vector3(0, 6, 0), ForceMode.Impulse);
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