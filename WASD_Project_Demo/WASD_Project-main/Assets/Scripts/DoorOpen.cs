using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOpen : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
  
        if (collision.gameObject.tag == "Player")
        {
            Invoke("NextStage", 1f);


        }
    }

    private void NextStage()
    {
        SceneManager.LoadScene("Dscene");
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
