using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Hit : MonoBehaviour
{
    private Animator animator;
    public float attackRestTime = 1;
    private float nextAttackTime = 0f;
    [SerializeField] private GameObject wave;
    private bool isShootAnimActive;
    [SerializeField] private AudioSource sfxTounge;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        sfxTounge = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                animator.SetTrigger("hit");
                if (sfxTounge)
                { sfxTounge.Play(); }
                nextAttackTime = Time.time + attackRestTime;
            }
        }

        isShootAnimActive = animator.GetCurrentAnimatorStateInfo(0).IsName("newToungeAnim");
        transform.parent.GetComponent<Player1Move>().IsShootAnimActive = isShootAnimActive;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player2") && isShootAnimActive)
        {
            Color winColor = transform.parent.GetComponent<SpriteRenderer>().color;
            winColor.a = 1;
            wave.GetComponent<Winning>().WinningMethode("red", winColor);
        }
    }
}