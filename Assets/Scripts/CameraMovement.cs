using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Simple camera movement with WASD, q, e, and the mouse when you rigth click
/// </summary>
public class CameraMovement : MonoBehaviour
{
    [Header("Move")]
    public float MoveSpeed = 4.0f;

    [Header("Rotation")]
    public float lookSpeedH = 2f;
    public float lookSpeedV = 2f;
    public float zoomSpeed = 2f;
    public float dragSpeed = 6f;


    private float yaw = 0f;
    private float pitch = 0f;

    private void Start()
    {
        pitch = Camera.main.transform.rotation.x;
        yaw = Camera.main.transform.rotation.y;
    }

    void Update()
    {
        CameraPosition();

        CameraRotation();
    }

    private void CameraPosition()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        float zInput = Input.GetAxis("CameraMovementVertical");

        Vector3 newPos = transform.position;

        newPos += transform.right* xInput * MoveSpeed * Time.deltaTime;
        newPos += transform.forward * yInput * MoveSpeed * Time.deltaTime;
        newPos += transform.up * zInput * MoveSpeed * Time.deltaTime;

        transform.position = newPos;
    }

    private void CameraRotation()
    {
        //Look around with Right Mouse
        if (Input.GetMouseButton(1))
        {
            yaw += lookSpeedH * Input.GetAxis("Mouse X");
            pitch -= lookSpeedV * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(pitch, yaw, 0f);
        }

        //drag camera around with Middle Mouse
        if (Input.GetMouseButton(2))
        {
            transform.Translate(-Input.GetAxisRaw("Mouse X") * Time.deltaTime * dragSpeed, -Input.GetAxisRaw("Mouse Y") * Time.deltaTime * dragSpeed, 0);
        }

        //Zoom in and out with Mouse Wheel
        transform.Translate(0, 0, Input.GetAxis("Mouse ScrollWheel") * zoomSpeed, Space.Self);
    }

}
