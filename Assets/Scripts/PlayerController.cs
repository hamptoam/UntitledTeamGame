using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

//hi guys it's Amii, Amelia, this is just the basic logic for up down left right 
    private Rigidbody playerRb;
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            playerRb.velocity = transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            playerRb.velocity = -transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerRb.velocity = transform.right * speed;

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerRb.velocity = -transform.right * speed;
        } 
    }
}
