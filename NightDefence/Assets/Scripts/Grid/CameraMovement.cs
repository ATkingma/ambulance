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
        controller.Move(-moveDir.normalized / Time.timeScale);

        if (Input.GetAxis("Mouse ScrollWheel") < 0f) // forward
        {
            controller.Move(new Vector3(Input.GetAxis("Mouse ScrollWheel"), Input.GetAxis("Mouse ScrollWheel"), 0) * -zoomSpeed);
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            controller.Move(new Vector3(Input.GetAxis("Mouse ScrollWheel"), Input.GetAxis("Mouse ScrollWheel"), 0) * -zoomSpeed);
        }
    }
}
