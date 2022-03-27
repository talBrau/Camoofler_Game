using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Hit : MonoBehaviour
{
    private Animator animator;
    
    public float attackRestTime = 1;

    private float nextAttackTime = 0f;
    private bool isShootAnimActive;

    [SerializeField]  AudioSource sfxTounge;

    [SerializeField] private GameObject wave;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sfxTounge = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                animator.SetTrigger("hit");
                sfxTounge.Play();
                nextAttackTime = Time.time +attackRestTime;
            }
        }
        isShootAnimActive = animator.GetCurrentAnimatorStateInfo(0).IsName("newToungeAnim");
        transform.parent.GetComponent<Player2Move>().IsShootAnimActive = isShootAnimActive;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") && isShootAnimActive)
        {
            Color winColor = transform.parent.GetComponent<SpriteRenderer>().color;
            winColor.a = 1;
            wave.GetComponent<Winning>().WinningMethode("blue", winColor);
        }
    }
}
