using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<PointInTime> pointInTimes = new List<PointInTime>();
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        Play();
       
    }
    
    // Update is called once per frame
    void Update()
    {
        
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
