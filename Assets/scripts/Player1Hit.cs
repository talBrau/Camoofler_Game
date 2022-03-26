using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Hit : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private Animator _playerAnimator;
    public float attackRestTime = 1;
    private float nextAttackTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        _playerAnimator = transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                _playerAnimator.SetTrigger("shoot");
                animator.SetTrigger("hit");
                nextAttackTime = Time.time +attackRestTime;
            }
        }

        transform.parent.GetComponent<Player1Move>().IsShootAnimActive =
            animator.GetCurrentAnimatorStateInfo(0).IsName("newToungeAnim");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player2"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
