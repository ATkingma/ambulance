using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    CharacterController controller;
    private Vector3 moveDir;
    public Camera mainCam;
    public float zoomSpeed;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void FixedUpdate()
    {
        moveDir.z = -Input.GetAxisRaw("Horizontal");
        moveDir.x = Input.GetAxisRaw("Vertical");
        if (Time.timeScale == 1)
        {
            controller.Move(-moveDir.normalized * 1);
        }
        if (Time.timeScale == 2)
        {
            controller.Move(-moveDir.normalized * 0.5f);
        }
        if (Time.timeScale == 5)
        {
            controller.Move(-moveDir.normalized * 0.2f);
        }
        if (Time.timeScale == 10)
        {
            controller.Move(-moveDir.normalized * 0.1f);
        }
        

        if (Input.GetAxis("Mouse ScrollWheel") < 0f) // forward
        {
            mainCam.fieldOfView += zoomSpeed;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            mainCam.fieldOfView -= zoomSpeed;
        }
        mainCam.fieldOfView = Mathf.Clamp(mainCam.fieldOfView, 30, 70);
    }
}
