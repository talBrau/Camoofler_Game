using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    public float rotSpeed = 10f;
    private Vector2 movement;
    private float rotation;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical"); 
        transform.position += movement.y * transform.up * Time.deltaTime * speed;
        rotation = -movement.x*rotSpeed;
        transform.Rotate(Vector3.forward*rotation);
    }
}
