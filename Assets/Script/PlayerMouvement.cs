using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : Recorder
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
    public float groundDistance = 0.3f;
    public LayerMask groundMask;

    private bool isGrounded;

    public GameObject Clone;
    public CameraMouvement camera;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    private void FixedUpdate()
    {
        Record();
    }
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);



    }

    public override void StopRecord()
    {
        camera.DropCube();
        controller.enabled = false;
        transform.position = pointInTimes[0].postion;
        transform.rotation = pointInTimes[0].rotation;
        controller.enabled = true;
        GameObject instance = Instantiate(Clone);
        instance.GetComponent<Player>().SetPointInTime(pointInTimes);
        pointInTimes = new List<PointInTime>();

    }

    protected override void Record()
    {
        pointInTimes.Add(new PointInTime(transform.position, transform.rotation));
    }
}
