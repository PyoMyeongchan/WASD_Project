using UnityEngine;

public class SavePoint : MonoBehaviour
{
    APlayerController controller;
    SpriteRenderer spriteRenderer;
    Collider2D col;
    public Sprite before;
    public Sprite after;

    public AudioSource SFX;
    public AudioClip point;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<APlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PointTouch();
            col.enabled = false;
            controller.UpdateSavePoint(transform.position);
            spriteRenderer.sprite = after;
            Debug.Log("π›¿¿");
        }   
    }

    void PointTouch()
    {
        SFX.PlayOneShot(point);
    }


}
