using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;

    public float moveSpeed = 5f;
    public float jumpForce = 100f;

    public float groundDistanceThreshold = 0.55f;

    public LayerMask whatIsGround;

    private bool _isGrounded;
    private bool _enabled;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _enabled = true;
    }

    void Update()
    {
        if (!_enabled) return;
        _isGrounded = Physics2D.Raycast(transform.position, Vector2.down,
            groundDistanceThreshold, whatIsGround);

        if(_isGrounded && Input.GetButtonDown("Jump"))
        {
            _animator.SetBool("Jumping", true);
            _rigidbody.velocity = Vector2.up * jumpForce;
        }
        else
        {
            _animator.SetBool("Jumping", false);
        }
        _animator.SetBool("Falling", !_isGrounded);
    }

    private void FixedUpdate()
    {
        if (!_enabled) return;
        float movement = moveSpeed * Input.GetAxisRaw("Horizontal");

        _animator.SetBool("Moving", movement != 0);

        if (movement > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (movement < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        _rigidbody.position += movement * Time.deltaTime * Vector2.right;
    }

    public void Enable()
    {
        _enabled = true;

    }

    public void Disable()
    {
        _enabled = false;

        _animator.SetBool("Moving", false);
        _animator.SetBool("Jumping", false);
        _animator.SetBool("Falling", false);
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
       if (other.gameObject.CompareTag("Hazards"))
        {
            gameManager.KillPlayer();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            gameManager.SetCheckpoint(other.transform);
        }
        else if (other.CompareTag("Collectible"))
        {
            gameManager.GotCollectible(other.transform);
            other.gameObject.SetActive(false);
        }
    }
}
