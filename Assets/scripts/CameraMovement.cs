using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject targetObject;
    
    private Transform target;

    // camera limits
    private float maxX = 40.5f;
    private float maxY = 20.5f;
    private float minX = -22.1f;
    private float minY = -9.9f;

    private void Start()
    {
        target = targetObject.transform;
    }

    void Update ()
    {
        transform.position = new Vector3(
            Mathf.Clamp(target.position.x, minX, maxX), 
            Mathf.Clamp(target.position.y, minY, maxY),
            transform.position.z); 
    }
}
