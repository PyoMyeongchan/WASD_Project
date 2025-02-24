using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class APlayerController : MonoBehaviour
{
    Rigidbody2D rbody;
    public float maxSpeed;
    SpriteRenderer spriteRenderer;
    Animator animator;
    public float jumpPw;
    public int jumpcount;
    bool isGround = false;
    float axisH = 0.0f;
    Vector2 savePoint;


    string current = "";
    string previous = " ";

    public enum AnimeState { AIDLE, ARun }


    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        isGround = true;
        jumpcount = 1;
        savePoint = transform.position;
        

    }

    private void Update()
    {

        axisH = Input.GetAxisRaw("Horizontal");


        if (axisH > 0.0f)
        {
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
        else if (axisH < 0.0f)
        {
            transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);

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

        if(isGround)
        { 
            jumpcount = 1;
            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                rbody.AddForce(Vector2.up * jumpPw, ForceMode2D.Impulse);
                isGround = false;
                jumpcount = 0;

            }
            

        }


    }



    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rbody.AddForce(Vector2.right * h,ForceMode2D.Impulse);

        if (rbody.linearVelocityX > maxSpeed)
        {
            rbody.linearVelocity = new Vector2(maxSpeed, rbody.linearVelocityY);
        }
        else if (rbody.linearVelocityX < maxSpeed * (-1))
        { 
            rbody.linearVelocity = new Vector2(maxSpeed*(-1), rbody.linearVelocityY);
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        { 
            isGround = true;
            jumpcount = 1;
        }

        if (collision.gameObject.tag == "Dead")
        {
            Dead();
        }
    }

    public void GameStop()
    {
        rbody.linearVelocity = new Vector2(0, 0);
    }

    public void Dead()
    {
        StartCoroutine(Respawn(2f));
       
    }


    IEnumerator Respawn(float duration)
    {
        GameStop();
        GetComponent<Collider2D>().enabled = false;
        rbody.AddForce(new Vector2(0, 7), ForceMode2D.Impulse);        
        yield return new WaitForSeconds(duration);
        GetComponent<Collider2D>().enabled = true;
        transform.position = savePoint;
        
    }
    public void UpdateSavePoint(Vector2 pos)
    {
        
        savePoint = pos;  
    }
}
