using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerK : MonoBehaviour
{

    private float xAxis, zAxis;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    public bool isjumping = false;
    public float jumpDelayTimer = 1f;

    private float mouseX;

    private Rigidbody playerBody;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //movememnt
        xAxis = Input.GetAxis("Horizontal");//A & D
        zAxis = Input.GetAxis("Vertical"); // W & S

        mouseX = Input.mousePosition.x;

        Vector3 movementVector = new Vector3(xAxis, 0f, zAxis);
        movementVector.Normalize();
        transform.position += movementVector * moveSpeed * Time.deltaTime;
    
        //jump
        if (Input.GetButtonDown("Jump") && !isjumping)
        {
            Jump();   
        }

        

        if (Input.GetMouseButton(1))
        {
            RotatePlayer();

        }
    }

    private void Jump()
    {
        isjumping = true;
        playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        
        Invoke(nameof(JumpReady), jumpDelayTimer);

    }

    private void JumpReady()
    {
        isjumping = false;
    }

    private void RotatePlayer()
    {
        transform.localRotation = Quaternion.Euler(0f, mouseX, 0f);
    }
}
