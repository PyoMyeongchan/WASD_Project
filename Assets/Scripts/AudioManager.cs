using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    AudioSource audioSource;
    public AudioClip clip;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬을 이동해도 AudioManager 오브젝트가 파괴되지 않음
        }
        else // 이미 존재할 때
        {
            Destroy(gameObject); // 새로 생성되는 MainScene의 AudioManager를 파괴해서 AudioManager는 하나만 남게됨
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = this.clip;
        audioSource.Play(); // 반복 재생, 지속적으로 재생
    }



}
