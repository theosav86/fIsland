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

        Cursor.lockState = CursorLockMode.Locked;

        cameraOriginalRotation = transform.rotation; 

        cameraOriginalPosition = transform.localPosition;
    }

    // Update is called once per frame
    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        //xRotation -= mouseY;

        //xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //transform.localRotation = Quaternion.Euler(xRotation, 0f, zRotation);

        if (Input.GetMouseButton(1))
        {
            Cursor.lockState = CursorLockMode.Confined;

            transform.LookAt(playerBody);
            transform.RotateAround(playerBody.position, Vector3.up, mouseX * sensitivity * Time.deltaTime);
        }
        else
        {
            playerBody.Rotate(Vector3.up * mouseX);
            Cursor.lockState = CursorLockMode.Locked;
        }

        if(Input.GetMouseButtonUp(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            transform.localPosition = cameraOriginalPosition;
            transform.LookAt(playerBody);
        }

    }
}
