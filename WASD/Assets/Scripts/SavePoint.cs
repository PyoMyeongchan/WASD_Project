using UnityEngine;

public class SavePoint : MonoBehaviour
{
    APlayerController controller;
    SpriteRenderer spriteRenderer;
    public Sprite before;
    public Sprite after;
 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<APlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            controller.UpdateSavePoint(transform.position);
            spriteRenderer.sprite = after;
            Debug.Log("π›¿¿");
        }   
    }

  
}
