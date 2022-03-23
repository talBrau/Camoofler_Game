using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Hit : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            animator.SetTrigger("hit");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "player 2")
        {
            other.gameObject.SetActive(false);
        }
    }
}
