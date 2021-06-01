using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Recorder : MonoBehaviour
{
    public bool record;
    protected List<PointInTime> pointInTimes = new List<PointInTime>();

    protected abstract void Record();
    public abstract void StopRecord();
}
