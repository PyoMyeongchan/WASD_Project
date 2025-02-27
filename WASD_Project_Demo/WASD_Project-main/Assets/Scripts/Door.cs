using UnityEditor;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject doorOpen;

    public AudioSource SFX;
    public AudioClip openSound;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("¿­¼è¾øÀ½");

            if (ItemKeeper.haskey > 0)
            {
                OpenSound();
                ItemKeeper.haskey--;
               Invoke("Destroydoor",1f);
                doorOpen.SetActive(true);
                
            }
        }
            
    }

    void OpenSound()
    {
        SFX.PlayOneShot(openSound);
    }

    void Destroydoor()
    {
        Destroy(gameObject);
    }

}
