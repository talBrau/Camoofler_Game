using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Move : MonoBehaviour
{
    public float speed = 5f;
    public float rotSpeed = 7f;
    private Vector2 movement;
    private float rotation;

    void Update()
    {
        movement.x = movement.y = 0;
        if (Input.GetKey(KeyCode.W))
        {
            movement.y = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement.y = -1;

        }
        if (Input.GetKey(KeyCode.A))
        {
            movement.x = 1;

        }
        if (Input.GetKey(KeyCode.D))
        {
            movement.x = -1;
        }
        transform.position += movement.y*transform.up * Time.deltaTime * speed;
        rotation = movement.x*rotSpeed;
        transform.Rotate(Vector3.forward*rotation);
    }
}
