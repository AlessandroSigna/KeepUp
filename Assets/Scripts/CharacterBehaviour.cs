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
    public float speed;
    public bool canBuild;

    private Rigidbody2D _rigidbody;
    private bool jumping = false;
	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
        isGrounded = IsGrounded();
        if (isGrounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            //jump
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpHeight);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //left
            _rigidbody.AddForce(new Vector2(-moveForce, 0), ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //right
            _rigidbody.AddForce(new Vector2(moveForce, 0), ForceMode2D.Force);
        }
        speed = _rigidbody.velocity.x;
        if (speed <= -maxSpeed)
            _rigidbody.velocity = new Vector2(-maxSpeed, _rigidbody.velocity.y);
        else if (speed >= maxSpeed)
            _rigidbody.velocity = new Vector2(maxSpeed, _rigidbody.velocity.y);
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
    
}
