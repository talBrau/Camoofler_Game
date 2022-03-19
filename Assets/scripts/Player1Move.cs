using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Move : MonoBehaviour
{
    public float speed = 5f;
    public float rotSpeed = 7f;
    private Vector2 movement;
    private float rotation;

    void Update()
    {
        movement.x = movement.y = 0;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movement.y = 1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            movement.y = -1;

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement.x = 1;

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movement.x = -1;

        }
        transform.position += movement.y*transform.up * Time.deltaTime * speed;
        rotation = movement.x*rotSpeed;
        transform.Rotate(Vector3.forward*rotation);
    }
}
