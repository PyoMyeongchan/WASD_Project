using UnityEngine;

public class CameraController : MonoBehaviour
{
    // ī�޶��� ��ũ�� ���� ��
    public float leftLimit = 0.0f;
    public float rightLimit = 0.0f;
    public float topLimit = 0.0f;
    public float bottomLimit = 0.0f;

    // ���� ��ũ��
    public GameObject subScreen;

    // ���� ��ũ�� ��� ó��
    public bool isForcrScrollX = false; // X����
    public bool isForcrScrollY = false; // Y����
    public float forceScrollSpeedX = 0.5f; // 1�� �� ������ X ������ �Ÿ�
    public float forceScrollSpeedY = 0.5f; // 1�� �� ������ Y ������ �Ÿ�
                                           //===================================================================




    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        float x = player.transform.position.x;
        float y = player.transform.position.y;
        float z = transform.position.z;

        // ���� ���� ��ũ��
        if (isForcrScrollX)
        {
            x = transform.position.x + (forceScrollSpeedX * Time.deltaTime);

        }
        // ���ι��� ����ȭ
        if (x < leftLimit)
        {
            x = leftLimit;

        }
        else if (x > rightLimit)
        {
            x = rightLimit;
        }

        // ���� ���� ��ũ��
        if (isForcrScrollY)
        {
            x = transform.position.y + (forceScrollSpeedY * Time.deltaTime);

        }


        // ���ι��� ����ȭ
        if (y < bottomLimit)
        {
            y = bottomLimit;
        }
        else if (y < topLimit)
        {
            y = topLimit;
        }

        // ������ ī�޶� ��ġ�� Vector3�� ǥ��
        Vector3 vector3 = new Vector3(x, y, z);
        // ī�޶��� ��ġ�� ������ ������ ����
        transform.position = vector3;

        // ���� ��ũ�� �۵�
        if (subScreen != null)
        {
            y = subScreen.transform.position.y;
            z = subScreen.transform.position.z;
            Vector3 v = new Vector3(x * 0.5f, y, z);
            subScreen.transform.position = v;
        }

    }
}
