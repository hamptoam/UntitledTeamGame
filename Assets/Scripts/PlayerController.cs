using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.4f;
    public Rigidbody PlayerRb;
    public bool PlayerIsOnTheGround = false;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    // Start is called before the first frame update
    private void Start()
    {
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        PlayerRb = GetComponent<Rigidbody>();
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
        if (Input.GetKey(KeyCode.Space) && PlayerIsOnTheGround)
        {
            PlayerIsOnTheGround = false;
            PlayerRb.AddForce(jump * jumpForce, ForceMode.Impulse);
        }
    }
    private void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Ground")
        {
            PlayerIsOnTheGround = true;
        }
    }
}