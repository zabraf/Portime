using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouvement : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform player;

    private float mouseX;
    private float mouseY;
    private float xRotation = 0f;
    public Rewinder rewinder;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-90f, 90f);
        player.Rotate(Vector3.up, mouseX);
        transform.localRotation = Quaternion.Euler(xRotation, 0F, 0F);
    }
}
