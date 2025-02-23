using UnityEngine;

public class Table : MonoBehaviour
{
    Collider2D collidered;
    public GameObject panel;

    private void Start()
    {
        collidered = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            panel.SetActive(true);
            Debug.Log("¿­¸²");
            Invoke("Close", 2);
        }

    }

    void Close()
    {
        panel.SetActive(false);
    
    }

}

