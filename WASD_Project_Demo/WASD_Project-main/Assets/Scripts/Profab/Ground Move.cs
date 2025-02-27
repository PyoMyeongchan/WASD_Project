using System;
using System.Collections;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    public int moveFlag = 1;
    public float movespeed = 3;
    public float movePower = 0.9f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine("GroundMoving");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        groundMove();
    }

    private void groundMove()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (this.moveFlag == 1)
        {
            moveVelocity = new Vector3(movePower, 0, 0);

        }
        else 
        {
            moveVelocity = new Vector3(-movePower, 0, 0);
        
        }
        transform.position += moveVelocity * movespeed * Time.deltaTime;
        
    }

    IEnumerator GroundMoving()
    {
        if (moveFlag == 1)
        { 
            moveFlag = 2;
        }
        else
        {
            moveFlag = 1;          
        }

        yield return new WaitForSeconds(2f);

        StartCoroutine("GroundMoving");
    
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            if (transform.position.y < col.transform.position.y)
                col.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }

}
