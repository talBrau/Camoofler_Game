using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject targetObject;
    
    private Transform target;

    private void Start()
    {
        target = targetObject.transform;
    }

    void Update ()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z); 
    }
}
