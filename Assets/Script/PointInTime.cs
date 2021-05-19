using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointInTime : MonoBehaviour
{
    public Vector3 postion;
    public Quaternion rotation;
    public float rotationCameraX;
    public PointInTime(Vector3 _position, Quaternion _rotation)
    {
        postion = _position;
        rotation = _rotation;
    }
    public PointInTime(Vector3 _position, Quaternion _rotation, float _rotationCameraX)
    {
        postion = _position;
        rotation = _rotation;
        rotationCameraX = _rotationCameraX;
    }
}
