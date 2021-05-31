using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : Recorder
{
    public bool isRecorded;
    public Rigidbody rigidbody;
    private int index = 0;
   
    void Start()
    {
        isRecorded = false;
        rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        index++;
        if (!isRecorded)
            Record();
        else
        {
            Play();
        }
    }

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            StopRecord();
            Debug.Log("test");
        }
    }
    public void Play()
    {
        if (index >= pointInTimes.Count - 1)
        {

            index = 0;
        }
        else
        {
            index++;
        }
        transform.position = pointInTimes[index].postion;
        transform.rotation = pointInTimes[index].rotation;
    }
    public override void StopRecord()
    {
        rigidbody.isKinematic = true;
        transform.position = pointInTimes[0].postion;
        transform.rotation = pointInTimes[0].rotation;
        rigidbody.isKinematic = false;
    }
}
