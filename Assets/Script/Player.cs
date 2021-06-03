using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<PointInTime> pointInTimes = new List<PointInTime>();
    private int index = 0;

    private void FixedUpdate()
    {
        Play();
       
    }
    
    public void SetPointInTime(List<PointInTime> _pointInTimes)
    {
        pointInTimes = _pointInTimes;
    }
    private void Play()
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
}
