using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour {

    public float moveForce = 0;
    public float maxSpeed = 0;
    public float jumpHeight = 0;
    public Transform[] groundCheckPoints;
    public LayerMask whatIsGround;
    public float groundCheckRadius;
    public bool isGrounded = false;
    public bool isSwimming = false;
    public float speed;
    public int boxesAvailable;
    public float swimSlowFactor = 2;
    public GameObject arrow;

    private Rigidbody2D _rigidbody;
    private bool jumping = false;
	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
        if (GameOverManager.Instance.paused)
        {
            return;
        }
        isGrounded = IsGrounded();

        float _jumpHeight = jumpHeight;
        float _moveForce = moveForce;
        float _maxSpeed = maxSpeed;

        if (isSwimming)
        {
            //_jumpHeight /= swimSlowFactor;
            _moveForce /= swimSlowFactor;
            _maxSpeed /= swimSlowFactor;
        }

        if (isGrounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            //jump
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpHeight);
            AudioManager.Instance.PlayJump();
            HideArrow();
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //left
            _rigidbody.AddForce(new Vector2(-_moveForce, 0), ForceMode2D.Force);
            transform.localScale = new Vector3(-1, 1, 1);
            HideArrow();
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //right
            _rigidbody.AddForce(new Vector2(_moveForce, 0), ForceMode2D.Force);
            transform.localScale = new Vector3(1, 1, 1);
            HideArrow();
        }
        speed = _rigidbody.velocity.x;
        if (speed <= -_maxSpeed)
            _rigidbody.velocity = new Vector2(-_maxSpeed, _rigidbody.velocity.y);
        else if (speed >= _maxSpeed)
            _rigidbody.velocity = new Vector2(_maxSpeed, _rigidbody.velocity.y);
    }

    bool IsGrounded()
    {
        foreach (Transform t in groundCheckPoints)
        {
            if (Physics2D.OverlapCircle(t.position, groundCheckRadius, whatIsGround))
                return true;
        }
        
        return false;
    }

    public void ShowArrow()
    {
        arrow.SetActive(true);
        Color tmp = GetComponent<SpriteRenderer>().color;
        tmp.a = 1f;
        GetComponent<SpriteRenderer>().color = tmp;
    }

    public void HideArrow()
    {
        arrow.SetActive(false);
    }

    public void BeInactive()
    {
        Color tmp = GetComponent<SpriteRenderer>().color;
        tmp.a = 0.5f;
        GetComponent<SpriteRenderer>().color = tmp;
    }
    
}
