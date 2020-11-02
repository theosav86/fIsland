using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerT : MonoBehaviour
{
    #region Variables

    public float moveSpeed = 5f;

    public float jumpForce = 5f;

    public bool isJumping = false;

    private float jumpDelayTimer = 1f;

    private Rigidbody playerBody;

    //mouse X Axis
    private float mouseX;

    //Keyboard Axes
    private float xAxis, zAxis;

    [Range(10f, 100f)]
    public float mouseSensitivity = 30f;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        //Player Input WASD
        xAxis = Input.GetAxis("Horizontal"); 
        zAxis = Input.GetAxis("Vertical");  

        //Mouse Input
        mouseX = Input.GetAxis("Mouse X");

        //Check for jumping
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            Jump();
        }

        //Check to rotate camera
        if(Input.GetMouseButton(1))
        {
            RotatePlayer();
        }
    }

    private void FixedUpdate()
    {
        Vector3 movementVector = new Vector3(xAxis, 0f, zAxis);

        Vector3 finalVelocity = movementVector * moveSpeed * Time.fixedDeltaTime;

        //Move the player
        playerBody.MovePosition(playerBody.position + finalVelocity);
      
    }

    private void Jump()
    {
        isJumping = true;

        //Add a vertical force to the Rigidbody of the player
        playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        //Invoke the Jump ready function after a short delay (jumpDelayTimer)
        Invoke(nameof(JumpReady), jumpDelayTimer);
    }

    private void JumpReady()
    {
        isJumping = false;
    }

    //Rotates the player's transform
    private void RotatePlayer()
    {
        transform.RotateAround(transform.position, Vector3.up * mouseX, Time.fixedDeltaTime * mouseSensitivity);
    }
}
