using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    CharacterController controller;
    private Vector3 moveDir;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void FixedUpdate()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.z = Input.GetAxisRaw("Vertical");

        controller.Move(-moveDir.normalized);
    }
}
