using System;
using UnityEngine;

public enum weaponAnim { AWeaponEffect, AWeapon};

public class AShootController : MonoBehaviour
{
    public float speed = 10;
    Animator animator;
    string current = "";

    void Start()
    {
        Invoke("DestroyAShoot", 2);
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (transform.rotation.y == 0)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(transform.right * -1 * speed * Time.deltaTime);

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �浹ü�� Ʈ�������� ȭ���� �θ� Ʈ�������� �ɰ̴ϴ�.
        transform.SetParent(collision.transform);

        //���� ���Ŀ��� �浹������ �����մϴ�.
        GetComponent<CircleCollider2D>().enabled = false;

        //���� �ùķ��̼ǵ� ��Ȱ��
        GetComponent<Rigidbody2D>().simulated = false;


        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
            current = Enum.GetName(typeof(weaponAnim), 0);

        }

        if (collision.gameObject.tag == "Monster")
        {
            Destroy(gameObject);
            current = Enum.GetName(typeof(weaponAnim), 0);
        }
        
        if (collision.gameObject.tag == "Dead")
        {
            Destroy(gameObject);
            current = Enum.GetName(typeof(weaponAnim), 0);
        }

        if (collision.gameObject.tag == "GroundMove")
        {
            Destroy(gameObject);
            current = Enum.GetName(typeof(weaponAnim), 0);
        }

    }

    void DestroyAShoot()
    {
        current = Enum.GetName(typeof(weaponAnim), 1);
        Destroy(gameObject);

    }
}
