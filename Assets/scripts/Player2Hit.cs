using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Hit : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetTrigger("hit");
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "player 1")
        {
            print("1 die");
        }
    }
}
