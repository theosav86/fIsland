using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookT : MonoBehaviour
{
    #region VARIABLES

    public float mouseX;
    public float mouseY;
    public float sensitivity = 100f;
    public float xRotation = 0f;
    public Transform playerBody;

    public Quaternion cameraOriginalRotation;
    private Vector3 cameraOriginalPosition;

    #endregion

    // Start is called before the first frame update
    void Start()
    {

        cameraOriginalRotation = transform.rotation; 

        cameraOriginalPosition = transform.localPosition;
    }

    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        //xRotation -= mouseY;

        //xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //transform.localRotation = Quaternion.Euler(xRotation, 0f, zRotation);
        
        if(Input.GetMouseButton(1))
        {
           // Cursor.lockState = CursorLockMode.Locked;
            transform.LookAt(playerBody);
            transform.RotateAround(playerBody.position, Vector3.up, mouseX * sensitivity * Time.fixedDeltaTime);
        }
        else
        {
            playerBody.Rotate(Vector3.up * mouseX);
        }

        if(Input.GetMouseButtonUp(1))
        {
            transform.localPosition = cameraOriginalPosition;
            transform.LookAt(playerBody);
        }

    }
}
