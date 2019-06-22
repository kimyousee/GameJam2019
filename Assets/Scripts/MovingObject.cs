using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public Vector3 startPoint;
    public Vector3 endPoint;
    public float speed = 1.0f;

    void Update()
    {
        transform.position = Vector3.Lerp(startPoint, endPoint, (Mathf.Sin(Time.time * speed ) + 1.0f) / 2);
    }
}
