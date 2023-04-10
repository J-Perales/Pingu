using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] [Range(0.1f, 50)] private float maxSpeed = 5;
    [SerializeField] [Range(0.1f, 50)] private float maxAcceleration=10;
    private float  _desiredSpeed;
    [SerializeField] private float jumpForce = 8;
    private Vector3 _velocity;
    private bool _canJump = false;
    public bool isGrounded = true;
    public bool isFacingRight = true;
    private Rigidbody2D _rb2D;
    // Start is called before the first frame update
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _rb2D.sleepMode = RigidbodySleepMode2D.NeverSleep;
    }

    // Update is called once per frame
    void Update()
    {

        float playerInput = Input.GetAxisRaw("Horizontal");
        _desiredSpeed = playerInput * maxSpeed;
        
        if (isGrounded)
            _canJump |= Input.GetKeyDown(KeyCode.Space);

    }

    //código para físicas, generalmente relacionado con el movimiento
    private void FixedUpdate()
    {
        
        _velocity = _rb2D.velocity;

        float maxSpeedChange = maxAcceleration * Time.deltaTime;
        _velocity.x = Mathf.MoveTowards(_velocity.x, _desiredSpeed, maxSpeedChange);
        
        if (_canJump && isGrounded)
        {
            _rb2D.AddForce(jumpForce * Vector3.up, ForceMode2D.Impulse);
            _canJump = false;
        }

        isGrounded = false;
        FaceDir(_velocity);
        _rb2D.velocity = new Vector2(_velocity.x,_rb2D.velocity.y);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            Vector3 normal = collision.GetContact(i).normal;
            isGrounded |= normal.y >= 0.9f;
        }
    }
    
    void FaceDir(Vector3 velocity)
    {
        if (velocity.x != 0)
            isFacingRight = velocity.x > 0;
    }
    
}
