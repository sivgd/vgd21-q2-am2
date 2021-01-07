using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float accel = 8f;
    public float speedCap = 5f;
    public float jumpForce = 400f;
    public bool grounded;
    //public GameObject respawnPoint;
    //public Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate() 
    {
        //Movement:
        if (Input.GetAxis("Horizontal") != 0) 
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                sr.flipX = false;
                rb.AddForce(new Vector2(accel, 0));
            }
            else 
            {
                sr.flipX = true;
                rb.AddForce(new Vector2(-accel, 0));
            }
        }
        //Speed Cap:
        if (rb.velocity.x > speedCap) 
        {
            rb.velocity = new Vector2(speedCap, rb.velocity.y);
        }
        if (rb.velocity.x < -speedCap)
        {
            rb.velocity = new Vector2(-speedCap, rb.velocity.y);
        }
               
    }

    void Update() 
    {
        //animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        //animator.SetFloat("SpeedV", Mathf.Abs(rb.velocity.y));

        //Jumping----------------------------------------------------------------

        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            //animator.SetBool("IsJumping", true);
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }

    public void die()
    {
        //transform.position = respawnPoint.transform.position;
        sr.flipX = false;
    }
    
    //Collisions-----------------------------------------------------------------

    private void OnTriggerStay2D(Collider2D collision) 
    {
        if (collision.tag == "Ground" || collision.tag == "Box")
        {
            grounded = true;
            //animator.SetBool("IsJumping", false);
        }
        //animator.SetBool("IsJumping", false);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        grounded = false;
    }
}
