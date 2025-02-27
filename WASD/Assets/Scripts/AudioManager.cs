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
            DontDestroyOnLoad(gameObject); // ���� �̵��ص� AudioManager ������Ʈ�� �ı����� ����
        }
        else // �̹� ������ ��
        {
            Destroy(gameObject); // ���� �����Ǵ� MainScene�� AudioManager�� �ı��ؼ� AudioManager�� �ϳ��� ���Ե�
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = this.clip;
        audioSource.Play(); // �ݺ� ���, ���������� ���
    }



}
