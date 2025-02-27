using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public GameObject itemPrefab;
    public bool isClosed = true;
    public AudioSource SFX;
    public AudioClip openSound;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isClosed && collision.gameObject.tag == "Player")
        { 
            isClosed = false;
            OpenSound();
            if (itemPrefab != null)
            {
                Instantiate(itemPrefab,transform.position, Quaternion.identity);
            }

            Invoke("DestroyBox", 0.5f);
        
        }
    }

    void OpenSound()
    {
        SFX.PlayOneShot(openSound);
    }

    void DestroyBox()
    {
        Destroy(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
