using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerT : MonoBehaviour
{
    #region Variables

    private float xAxis, zAxis;

    public float moveSpeed = 5f;

    public float jumpForce = 5f;

    public bool isJumping = false;

    private float jumpDelayTimer = 1f;

    private Rigidbody playerBody;

    private float mouseX;

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
        xAxis = Input.GetAxis("Horizontal"); // A & D
        zAxis = Input.GetAxis("Vertical");  // W & S

        mouseX = Input.GetAxis("Mouse X");

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            Jump();
        }

        if(Input.GetMouseButton(1))
        {
            RotatePlayer();
        }
    }

    private void FixedUpdate()
    {
        Vector3 movementVector = new Vector3(xAxis, 0f, zAxis);

        movementVector.Normalize();

        playerBody.position += movementVector * moveSpeed * Time.fixedDeltaTime;        
    }

    private void Jump()
    {
        isJumping = true;

        playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        Invoke(nameof(JumpReady), jumpDelayTimer);
    }

    private void JumpReady()
    {
        isJumping = false;
    }

    private void RotatePlayer()
    {
        //transform.localRotation = Quaternion.Euler(0f, mouseX, 0f);
        transform.RotateAround(transform.position, Vector3.up * mouseX, Time.fixedDeltaTime * mouseSensitivity);
    }
}
