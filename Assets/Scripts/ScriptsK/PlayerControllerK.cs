using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerK : MonoBehaviour
{
    #region Variables

    public float moveSpeed;

    public float jumpForce = 5f;

    public bool isJumping = false;

    private float jumpDelayTimer = 1f;

    private Rigidbody playerBody;

    //Keyboard Axes
    private float xAxis, zAxis;

    private Vector3 xInput, zInput = new Vector3();

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

        xInput = xAxis * transform.right;
        zInput = zAxis * transform.forward;

        //Check for jumping
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Vector3 movementVector = xInput + zInput ;

        Vector3 finalVelocity = movementVector * moveSpeed * Time.fixedDeltaTime;

        finalVelocity = Vector3.ClampMagnitude(finalVelocity, 1f) * moveSpeed * Time.deltaTime;

        finalVelocity.y = playerBody.velocity.y;

        //Move the player
        playerBody.velocity = (finalVelocity);
      
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
  /*  private void RotatePlayer()
    {
        transform.RotateAround(transform.position, Vector3.up * mouseX, Time.fixedDeltaTime * mouseSensitivity);
    }*/
}
