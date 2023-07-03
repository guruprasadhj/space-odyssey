using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;
    
    private float dirX=0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float  jumpForce= 7f;

    private enum MovementState { idle, running, jumping,falling};
    private MovementState state = MovementState.idle;

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource runningSoundEffect; 

    // Start is called before the first frame update
    private void Start()
    {
      Debug.Log("Hello WOrld!!");  
      rb = GetComponent<Rigidbody2D>();
      coll = GetComponent<BoxCollider2D>();
      sprite = GetComponent<SpriteRenderer>();
      anim = GetComponent<Animator>();
    //   runningSoundEffect = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX*moveSpeed,rb.velocity.y);

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play(); 
            rb.velocity = new Vector2(rb.velocity.x,jumpForce); 
        }
        updateAnimationState();
    }

    private void updateAnimationState(){
        MovementState state;
        if(dirX > 0f)
        { 
            if(!runningSoundEffect.isPlaying){
                runningSoundEffect.Play();
            }
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if(dirX < 0f)
        {
            if(!runningSoundEffect.isPlaying){
                runningSoundEffect.Play();
            }
            state = MovementState.running;
            sprite.flipX =true;
        }
        else
        {
            runningSoundEffect.Stop();
           state = MovementState.idle;
        }
        if(rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if(rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state",(int)state);
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center,coll.bounds.size,0f,Vector2.down,.1f,jumpableGround);
    }
}
