using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : Recorder
{
    public bool isRecorded;
    private Rigidbody rigidbody;
    private int index = 0;

    void Start()
    {
        isRecorded = false;
        
        rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
       
        if (!isRecorded)
            Record();
        else
        {
            Play();
        }
       
        index++;
    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            StopRecord();
        }
    }

    public void Play()
    {
        if (index < pointInTimes.Count)
        {
            transform.position = pointInTimes[index].postion;
            transform.rotation = pointInTimes[index].rotation;
        }
       
    }
    public override void StopRecord()
    {
        this.rigidbody.isKinematic = true;
        transform.position = pointInTimes[0].postion;
        transform.rotation = pointInTimes[0].rotation;
        this.rigidbody.isKinematic = false;
        isRecorded = true;
        index = 0;
    }

    protected override void Record()
    {
        pointInTimes.Insert(index,new PointInTime(transform.position, transform.rotation));
    }
}
