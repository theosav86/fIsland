using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookT : MonoBehaviour
{
    public float mouseX;
    public float mouseY;
    public float sensitivity = 100f;
    public float xRotation = 0f;
    public Transform playerBody;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.fixedDeltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.fixedDeltaTime;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //transform.localRotation = Quaternion.Euler(xRotation, 0f, zRotation);

        playerBody.Rotate(Vector3.up * mouseX);

    }
}
