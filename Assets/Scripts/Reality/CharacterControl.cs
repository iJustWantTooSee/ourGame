
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterControl : MonoBehaviour
{

    private Animator anim;
    public float speed;
    private float moveInput;
    private Rigidbody2D rb;
    private bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput*speed, rb.velocity.y);
        if (!facingRight && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight && moveInput < 0)
        {
            Flip();
        }
    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    //Animator anim;
    //float dirX, moveSpeed;
    //private bool m_FacingRight = true;  // For determining which way the player is currently facing.



    //// Start is called before the first frame update
    //void Start(){
    //    anim = GetComponent<Animator>();
    //    moveSpeed = 5f;
    //}

    //// Update is called once per frame
    //void Update(){
    //    dirX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
    //    transform.position = new Vector2(transform.position.x + dirX, transform.position.y);
    //    if (dirX != 0)
    //        anim.setBool("isWalking", true);
    //    else
    //        anim.setBool("isWalking", false);
    //}

}
