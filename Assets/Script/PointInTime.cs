using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointInTime
{
    public Vector3 postion;
    public Quaternion rotation;
    public PointInTime(Vector3 _position, Quaternion _rotation)
    {
        postion = _position;
        rotation = _rotation;
    }
}
