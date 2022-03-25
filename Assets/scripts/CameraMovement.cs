using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject targetObject;
    
    private Transform target;

    // camera limits
    private float maxX = 21.35f;
    private float maxY = 10.7f;
    private float minX = -3.06f;
    private float minY = -0.11f;

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
