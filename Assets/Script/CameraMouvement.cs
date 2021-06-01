using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouvement : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform player;
    private GameObject cube;
    private RaycastHit hit;
    public Transform grabPose;
    public float velocity = 10f;
    private float mouseX;
    private float mouseY;
    private float xRotation = 0f;
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
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(transform.position, transform.forward,out hit,5) && hit.transform.GetComponent<Rigidbody>()){
            cube = hit.transform.gameObject;
            if (cube.gameObject.tag != "Cube")
                cube = null;
            if (cube != null) { 
                cube.GetComponent<Rigidbody>().isKinematic = true;
                cube.GetComponent<CubeController>().isRecorded = false;
            }
        }
        else if(Input.GetMouseButtonUp(0)){
            if(cube != null)
            { 
                cube.GetComponent<Rigidbody>().isKinematic = false;
                cube = null;
            }
        }
        if (cube)
        {
            cube.transform.position = grabPose.transform.position;
            //cube.GetComponent<Rigidbody>().velocity = velocity * (grabPose.position - cube.transform.position);
        }
    }
}
