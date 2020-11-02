using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerK : MonoBehaviour
{
    private float mouseX;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.mousePosition.x;

        if (Input.GetMouseButton(1))
        {
            transform.localRotation = Quaternion.Euler(0f, mouseX, 0f);

        }
    }
}
