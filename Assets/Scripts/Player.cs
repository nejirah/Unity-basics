using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private LayerMask playerMask;
    private int superJumpsRemaining;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate() // it is called with fizic engine
    {
        GetComponent<Rigidbody>().velocity = new Vector3(horizontalInput, GetComponent<Rigidbody>().velocity.y, 0);
        if (Physics.OverlapSphere(groundCheckTransform.position,0.1f,playerMask).Length == 0)
        {
            return;
        }
        if (jumpKeyWasPressed)
        {
            float jumpPower = 5;
            if (superJumpsRemaining > 0)
            {
                jumpPower *= 1.5f;
                superJumpsRemaining--;
            }
            {
                
            }
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer ==9)
        {
            Destroy(other.gameObject);
            superJumpsRemaining++;
        }
    }
}
