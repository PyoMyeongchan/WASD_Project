using System;
using UnityEngine;

public class DPlayerController : MonoBehaviour
{
    Rigidbody2D rbody;
    public float maxSpeed;
    SpriteRenderer spriteRenderer;
    Animator animator;
    public float jumpPw;
    public int jumpcount;
    bool isGround = false;

    string current = "";
    string previous = " ";

    public enum AnimeState { DIDLE, DRun }


    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        isGround = true;
        jumpcount = 1;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
            rbody.linearVelocity = new Vector2(rbody.linearVelocity.normalized.x * 0.5f, rbody.linearVelocity.y);
        }

        if (rbody.linearVelocity.normalized.x == 0)
        {
            current = Enum.GetName(typeof(AnimeState), 0);
        }
        else
        {
            current = Enum.GetName(typeof(AnimeState), 1);
        }


        if (current != previous)
        {
            previous = current;
            animator.Play(current);
        }

        if (isGround)
        {
            jumpcount = 1;
            if (Input.GetButtonDown("Jump"))
            {
                rbody.AddForce(Vector2.up * jumpPw, ForceMode2D.Impulse);
                isGround = false;
                jumpcount = 0;

            }


        }

    }



    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rbody.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rbody.linearVelocityX > maxSpeed)
        {
            rbody.linearVelocity = new Vector2(maxSpeed, rbody.linearVelocityY);
        }
        else if (rbody.linearVelocityX < maxSpeed * (-1))
        {
            rbody.linearVelocity = new Vector2(maxSpeed * (-1), rbody.linearVelocityY);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
            jumpcount = 1;
        }
    }

}
