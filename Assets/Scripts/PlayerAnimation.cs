using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private PlayerMovement playerMovement;
    private Rigidbody2D _rb2d;
    private readonly int _animSpeed = Animator.StringToHash("Speed");
    private readonly int _animVelocityY = Animator.StringToHash("VelocityY");
    private readonly int _animIsGrounded = Animator.StringToHash("IsGrounded");
    private readonly int _animAttackA= Animator.StringToHash("AttackA");
    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat(_animSpeed, Mathf.Abs(_rb2d.velocity.x));
        animator.SetFloat(_animVelocityY, _rb2d.velocity.y);
        animator.SetBool(_animIsGrounded, playerMovement.isGrounded);
        
        if (Input.GetKeyDown(KeyCode.Q))
            animator.SetTrigger(_animAttackA);
        renderer.flipX = !playerMovement.isFacingRight;
    }
}
