using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxControl : MonoBehaviour
{
    private bool isInsideBox = false;
    private bool isFullyInsideBox = false;
    [SerializeField] private bool isPinkBox = true;
    private Collider2D player1Bc;
    [SerializeField] private Player1Move player1;

    [SerializeField] private Collider2D _boxCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        player1Bc = player1.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInsideBox)
        {
            if(_boxCollider2D.bounds.Contains(player1Bc.bounds.max) && _boxCollider2D.bounds.Contains(player1Bc.bounds.min))
            {
                isFullyInsideBox = true;
            }
            else
            {
                isFullyInsideBox = false;
            }
        }
        player1.setInsideBox(isFullyInsideBox);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Pink") && isPinkBox) || (other.gameObject.CompareTag("Blue") && !isPinkBox))
        {
            isInsideBox = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Pink") && isPinkBox) || (other.gameObject.CompareTag("Blue") && !isPinkBox))
        {
            isFullyInsideBox = false;
            isInsideBox = false;
        }
        
       
    }
}
