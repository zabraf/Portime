using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Recorder : MonoBehaviour
{
    public bool record;
    protected List<PointInTime> pointInTimes = new List<PointInTime>();
    public const float RecordTimeInSecond = 10F;
   
    protected void Record()
    {
        if (pointInTimes.Count > Mathf.Round(RecordTimeInSecond / Time.fixedDeltaTime))
        {
            pointInTimes.RemoveAt(0);
        }
        pointInTimes.Add(new PointInTime(transform.position, transform.rotation));
    }
    public abstract void StopRecord();
}
