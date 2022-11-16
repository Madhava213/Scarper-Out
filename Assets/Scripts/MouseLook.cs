using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour

{
    public Transform playerBody;
    public float mouseSensitivity = 100f;
    private float xRotation = 0f;
    void Start()
    {
        // Lock the cursor to prevent it from going out of window
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get Mouse Input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Clamp Rotation
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply Mouse Look Movement
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}