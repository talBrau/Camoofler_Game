using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Hit : MonoBehaviour
{
    private Animator animator;
    
    public float attackRestTime = 1;

    private float nextAttackTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                animator.SetTrigger("hit");
                nextAttackTime = Time.time +attackRestTime;
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "player red")
        {
            other.gameObject.SetActive(false);
        }
    }
}
