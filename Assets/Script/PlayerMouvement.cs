using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController controller;

    private float x;
    private float z;

    private float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    private Vector3 velocity;

    public Transform groundCheck;
    public float groundDIstance = 0.3f;
    public LayerMask groundMask;

    private bool isGrounded;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDIstance, groundMask);
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        Vector3 move = transform.right * x + transform.forward * z;

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        controller.Move(move * speed * Time.deltaTime);
        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
}
