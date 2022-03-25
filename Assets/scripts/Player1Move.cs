using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player1Move : MonoBehaviour
{
    #region Public fields
    public float speed;
    public float rotSpeed ;
    #endregion
    
    #region Private fields

    private Vector2 _movement;
    private float _rotation;
    private bool _isFullyInsideBox; // only when the player is fully inside
    private bool _isInsideBox; // when player enters box trigger
    private Collider2D _curBox; // The current box that the player is in, Null if he doesent touch
    
    #endregion

    #region Serialized fields

    [SerializeField] private Animator _animator;
    [FormerlySerializedAs("_spriteRenderer")] [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Collider2D player1Bc;
    #endregion

    #region Event functions

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player1Bc = GetComponent<Collider2D>();
        _animator = GetComponent<Animator>();

    }

    void Update()
    {
        
        MovePlayer();
        CheckInsideBox();
        UpdateCamoflage();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Pink"))
        {
            _isInsideBox = true;
            _curBox = col;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pink"))
        {
            _isInsideBox = false;
            _curBox = null;
        }
    }

    #endregion

    #region Private methods

    private void UpdateCamoflage()
    {
        if (_isFullyInsideBox && _movement == Vector2.zero)
        {
            spriteRenderer.enabled = false;
        }
        else
        {
            spriteRenderer.enabled = true;
        }
    }

    private void CheckInsideBox()
    {
        if (_isInsideBox)
        {
            print("PLayer1 inside");
            if (_curBox.bounds.Contains(player1Bc.bounds.max) &&
                _curBox.bounds.Contains(player1Bc.bounds.min))
            {
                _isFullyInsideBox = true;
                print("PLayer1 fully in");
            }
            else
            {
                _isFullyInsideBox = false;
            }
        }
    }

    private void MovePlayer()
    {
        _movement.x = _movement.y = 0;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _movement.y = 1;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            _movement.y = -1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _movement.x = 1;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            _movement.x = -1;
        }

        transform.position += _movement.y * transform.up * Time.deltaTime * speed;
        _rotation = _movement.x * rotSpeed;
        transform.Rotate(Vector3.forward * _rotation);

        if (_movement == Vector2.zero)
        {
            _animator.SetBool("isMoving",false);
        }
        else
        {
            _animator.SetBool("isMoving",true);

        }
    }

    #endregion
}
