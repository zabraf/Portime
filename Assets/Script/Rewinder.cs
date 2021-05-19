using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewinder : MonoBehaviour
{
    private const float RecordTimeInSecond = 5f;

    private bool isRewinded = false;
    public Transform rotationCamera;
    private List<PointInTime> pointInTimes = new List<PointInTime>() ;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartRewind();
        }
        if (Input.GetKeyUp(KeyCode.Return))
        { 
            StopRewind();
        }

    }
    private void FixedUpdate()
    {
        if (isRewinded)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }
    private void Rewind()
    {
        if (pointInTimes.Count > 0 )
        {
            transform.position = pointInTimes[0].postion;
            transform.rotation = pointInTimes[0].rotation;
            pointInTimes.RemoveAt(0);

        }
        
    }
    private void Record()
    {
        if (pointInTimes.Count > Mathf.Round(RecordTimeInSecond / Time.fixedDeltaTime))
        {
            pointInTimes.RemoveAt(pointInTimes.Count - 1);
        }
        pointInTimes.Insert(0, new PointInTime(transform.position, transform.rotation));
    }
    public void StartRewind()
    {
        isRewinded = true;
    }

    public void StopRewind()
    {
        isRewinded = false;
    }
}
