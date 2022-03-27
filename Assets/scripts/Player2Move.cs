
using UnityEngine;
using UnityEngine.Serialization;

public class Player2Move : MonoBehaviour
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
    private bool _isShootAnimActive = false;
    public bool IsShootAnimActive
    {
        set => _isShootAnimActive = value;
    }

    #endregion

    #region Serialized fields

    [FormerlySerializedAs("_spriteRenderer")] [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator _animator;
    [SerializeField] private Collider2D player2Bc;
    [SerializeField] private Animator _eyesAnimator;
    [SerializeField] private EyesBlink _eyesBlink;

    #endregion

    #region Event functions

    private void Start()
    {
        player2Bc = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _eyesBlink = GetComponentInChildren<EyesBlink>();
        _eyesAnimator = _eyesBlink.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        MovePlayer();
        CheckInsideBox();
        UpdateCamoflage();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Blue"))
        {
            _isInsideBox = true;
            _curBox = col;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Blue"))
        {
            _isInsideBox = false;
            _isFullyInsideBox = false;
            _curBox = null;
        }
    }

    #endregion

    #region private methods

    private void MovePlayer()
    {
        _movement.x = _movement.y = 0;
        if (Input.GetKey(KeyCode.W))
        {
            _movement.y = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _movement.y = -1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _movement.x = 1;
        }

        if (Input.GetKey(KeyCode.D))
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

    private void UpdateCamoflage()
    {
        if (_isFullyInsideBox && _movement == Vector2.zero && !_isShootAnimActive)
        {
            // spriteRenderer.enabled = false;
            _animator.SetBool("isFullyIn",true);
            _eyesAnimator.SetBool("isHiding",true);

            
        }
        else
        {
            // spriteRenderer.enabled = true;
            _animator.SetBool("isFullyIn",false);
            _eyesAnimator.SetBool("isHiding",false);

        }
    }

    private void CheckInsideBox()
    {
        if (_isInsideBox)
        {
            // print("PLayer2 inside");
            if (_curBox.bounds.Contains(player2Bc.bounds.max) &&
                _curBox.bounds.Contains(player2Bc.bounds.min))
            {
                _isFullyInsideBox = true;
                // print("PLayer2 fully in");
            }
            else
            {
                _isFullyInsideBox = false;
            }
        }
    }

    #endregion
}
