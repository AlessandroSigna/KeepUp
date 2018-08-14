using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour {

    public float moveForce = 0;
    public float maxSpeed = 0;
    public float jumpHeight = 0;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    public float groundCheckRadius;
    public bool isGrounded = false;
    public float speed;

    private Rigidbody2D _rigidbody;
    private bool jumping = false;
	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
        if (isGrounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)))
        {
            //jump
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpHeight);
        }
        if (Input.GetKey(KeyCode.A) )
        {
            //left
            _rigidbody.AddForce(new Vector2(-moveForce, 0), ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.D) )
        {
            //right
            _rigidbody.AddForce(new Vector2(moveForce, 0), ForceMode2D.Force);
        }
        speed = _rigidbody.velocity.x;
        if (speed <= -maxSpeed)
            _rigidbody.velocity = new Vector2( -maxSpeed, _rigidbody.velocity.y);
        else if (speed >= maxSpeed)
            _rigidbody.velocity = new Vector2(maxSpeed, _rigidbody.velocity.y);
    }
}
