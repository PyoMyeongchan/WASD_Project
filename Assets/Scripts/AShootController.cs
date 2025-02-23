using UnityEngine;

public class AShootController : MonoBehaviour
{
    public float speed = 10;
    
    void Start()
    {
        Invoke("DestroyAShoot", 2);
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
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

    void DestroyAShoot()
    {
        Destroy(gameObject);

    }
}
