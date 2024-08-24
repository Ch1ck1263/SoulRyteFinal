using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class MovementV2 : MonoBehaviour
{
    private float horizontal;

    AudioSource jumpSound;
    
    private int flip = 1;
    float horizontalInput;
    public float moveSpeed = 5f;
    bool isFacingRight = false;

    private bool canDash = true;
    private bool isDashing;
    public float dashingPower = 14f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    Rigidbody2D rb;
    Animator animator;

    public float jumpPower = 4;
    public bool isGrounded = false;

    private bool db;

    SpriteRenderer sprite;

    [SerializeField] private TrailRenderer tr;
    
    // Start is called before the first frame update
    void Start()
    {
        jumpSound = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        
        if(isDashing){
            return;
        }
        
        horizontalInput = Input.GetAxis("Horizontal");

        if(isGrounded && !Input.GetButton("Jump")){
            db = false;
        }
        

        FlipSprite();

        if(Input.GetButtonDown("Jump") ){
            if(isGrounded || db){
                jumpSound.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                isGrounded = false;
                animator.SetBool("isJumping", !isGrounded);

                db = !db;
            }
        }

        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f){
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    
        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash){
            StartCoroutine(Dash());
        }
    }

   
    
    private void FixedUpdate(){
        if(isDashing){
            return;
        }
        
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    void FlipSprite(){
        if(isFacingRight && horizontalInput > 0f || !isFacingRight && horizontalInput <   0f){
            sprite.flipX = !isFacingRight;
            isFacingRight = !isFacingRight;
            flip *= -1;
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision){
        isGrounded = true;
        animator.SetBool("isJumping", !isGrounded);

    }

    private IEnumerator Dash(){
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(flip * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;        
    }
}
