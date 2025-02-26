using System;
using System.Collections;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public static string state = "Playing";
    public int playerHp = 3;
    public int maxHp = 3;
    bool isUndamage;





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
        state = "Playing";

        

    }

    private void Update()
    {
        if (state != "Playing")
        {
            return;
        }
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

        if (isGround)
        {
            jumpcount = 1;
            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                rbody.AddForce(Vector2.up * jumpPw, ForceMode2D.Impulse);
                isGround = false;
                jumpcount = 0;

            }


        }

        if (playerHp == 0)
        {
            if (state != "Playing")
            {
                Dead();
            
            }
        }


    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if (state != "Playing")
        {
            return;
        }


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

        if (collision.gameObject.tag == "Dead")
        {
            Dead();

        }
        if (collision.gameObject.tag == "Monster")
        {
            GetDamage(collision.transform.position);
        
        }


    }

    private void GetDamage(Vector2 monster)
    {
        playerHp--;
        gameObject.layer = 9;
        rbody.linearVelocity = new Vector2(0, 0);
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        int dir = transform.position.x - monster.x > 0 ? 1 : -1;
        rbody.AddForce(new Vector2(dir, 1) * 2f, ForceMode2D.Impulse);

        Invoke("OffDamaged", 1.5f);

        if (playerHp == 0)
        {
            Dead();
            spriteRenderer.color = new Color(1, 1, 1, 1);
        }

    }

    void OffDamaged()
    {
        gameObject.layer = 6;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    
    }



    public void GameStop()
    {
        state = "gameover";
        rbody.linearVelocity = new Vector2(0, 0);
    }

    public void Dead()
    {
        
        StartCoroutine(Respawn(2f));

    }


    IEnumerator Respawn(float duration)
    {

        GameStop();
        rbody.AddForce(new Vector2(0, 7), ForceMode2D.Impulse);
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
        state = "Playing";
        GetComponent<Collider2D>().enabled = true;
        playerHp = 3;
        transform.position = savePoint;
   


    }
    public void UpdateSavePoint(Vector2 pos)
    {

        savePoint = pos;
    }


}
