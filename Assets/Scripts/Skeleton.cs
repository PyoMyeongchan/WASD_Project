using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Skeleton : MonoBehaviour
{
    public int hp = 2;
    public float speed = 3.0f;
    public List<string> animeList = new List<string> { "SkeletonRun", "SkeletonDead" };
    Vector3 movement;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    int movementFlag = 0;
    public int nextMove = 1;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

       StartCoroutine("ChangeMovement");
    }

    IEnumerator ChangeMovement()
    {
        movementFlag = Random.Range(0, 3);
        if (movementFlag == 0)
        {
            var animator = GetComponent<Animator>();
            animator.Play(animeList[0]);
        }

        yield return new WaitForSeconds(3.0f);

        StartCoroutine("ChangeMovement");
    }


    private void FixedUpdate()
    {

        Move();

        Vector2 frontVec = new Vector2(rb.position.x + nextMove, rb.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("ground"));
        if (rayHit.collider == null)
        {
            Debug.Log("낭떠러지 감지");

            CancelInvoke();
        }
    }

    private void Move()
    {
        Vector3 moveVelocity = Vector3.zero;
        if (movementFlag == 1)
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (movementFlag == 2)
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(1, 1, 1);
        }
        transform.position += moveVelocity * speed * Time.deltaTime;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            hp--;

            if (hp <= 0)
            {
                
                GetComponent<CapsuleCollider2D>().enabled = false;
                GetComponent<Rigidbody2D>().gravityScale = 0.0f;
                var animator = GetComponent<Animator>();
                animator.Play(animeList[1]);
                Destroy(gameObject, 1f);


            }
        }



    }

 

}
