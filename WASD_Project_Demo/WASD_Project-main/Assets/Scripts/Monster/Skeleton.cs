using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Skeleton : MonoBehaviour
{
    public int hp = 2;
    public int maxHp = 2;
    public float speed = 3.0f;
    static public bool live = true;
    public List<string> animeList = new List<string> { "SkeletonRun", "SkeletonDead" };
    Vector3 movement;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    int movementFlag = 0;
    public int nextMove = 1;

    public AudioSource skeletonAudio;
    public AudioClip damageSound;
    public AudioClip deadSound;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {


        if (live == false)
        {
            return;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine("ChangeMovement");
    }

    IEnumerator ChangeMovement()
    {
        movementFlag = Random.Range(-1, 2);
        if (movementFlag == 0)
        {
            var animator = GetComponent<Animator>();
            animator.Play(animeList[0]);
        }

        yield return new WaitForSeconds(2.0f);

        StartCoroutine("ChangeMovement");
    }


    private void FixedUpdate()
    {
        if (live == false)
        {
            return;
        }

        Move();


        Vector2 frontVec = new Vector2(rb.position.x, rb.position.y);
        Vector2 rayDirection = Vector2.down;

        // 왼쪽을 볼 때 (nextMove < 0), 왼쪽에 레이 쏘기
        if (nextMove < 0)
        {
            frontVec.x = rb.position.x - 0.5f;  // 왼쪽에 레이캐스트
        }
        // 오른쪽을 볼 때 (nextMove > 0), 오른쪽에 레이 쏘기
        else if (nextMove > 0)
        {
            frontVec.x = rb.position.x + 0.5f;  // 오른쪽에 레이캐스트
        }

        Debug.DrawRay(frontVec, rayDirection * 1f, new Color(0, 1, 0));  // 레이의 방향을 설정하여 그려줌

        // Raycast: 레이의 방향에 맞춰 낭떠러지를 감지 (위치에서 아래로 레이를 쏘는 것)
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, rayDirection, 1f, LayerMask.GetMask("ground"));

        // 낭떠러지 감지 시
        if (rayHit.collider == null)
        {
            // 낭떠러지가 없으면 방향 반전
            nextMove = -nextMove;
            movementFlag = (nextMove > 0) ? 1 : -1;  // `nextMove`에 따라 `movementFlag` 업데이트

        }
        else
        {
            nextMove = -nextMove;

        }
   
    }

    private void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        // `movementFlag`에 따라 이동 방향 설정
        if (movementFlag == -1)  // 왼쪽 이동
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(movementFlag, 1, 1);  // 왼쪽을 향하도록 스케일 변경
        }
        else if (movementFlag == 1)  // 오른쪽 이동
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(movementFlag, 1, 1);  // 오른쪽을 향하도록 스케일 변경
        }

        // 일정 속도로 계속 이동
        transform.position += moveVelocity * speed * Time.deltaTime;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
           
            GetDamage(collision.transform.position);
            DamageSound();
            if (hp <= 0)
            {
                DeadSound();
                speed = 0;
                rb.linearVelocity = new Vector2(0, 0);
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<Rigidbody2D>().gravityScale = 0.0f;
                var animator = GetComponent<Animator>();
                animator.Play(animeList[1]);
                Destroy(gameObject, 1f);

            }

        }



    }

    private void GetDamage(Vector2 player)
    {
        hp--;        
        rb.linearVelocity = new Vector2(0, 0);        
        int dir = transform.position.x - player.x > 0 ? 1 : -1;
        rb.AddForce(new Vector2(dir, 1) * 2f, ForceMode2D.Impulse);
    }


    public void DamageSound()
    {
        skeletonAudio.PlayOneShot(damageSound);
    }

    public void DeadSound()
    {
        skeletonAudio.PlayOneShot(deadSound);
    }


}
