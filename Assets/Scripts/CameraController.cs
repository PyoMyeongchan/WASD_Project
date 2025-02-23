using UnityEngine;

public class CameraController : MonoBehaviour
{
    // 카메라의 스크롤 제한 값
    public float leftLimit = 0.0f;
    public float rightLimit = 0.0f;
    public float topLimit = 0.0f;
    public float bottomLimit = 0.0f;

    // 서브 스크린
    public GameObject subScreen;

    // 강제 스크롤 기능 처리
    public bool isForcrScrollX = false; // X조건
    public bool isForcrScrollY = false; // Y조건
    public float forceScrollSpeedX = 0.5f; // 1초 간 움직일 X 방향의 거리
    public float forceScrollSpeedY = 0.5f; // 1초 간 움직일 Y 방향의 거리
                                           //===================================================================




    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        float x = player.transform.position.x;
        float y = player.transform.position.y;
        float z = transform.position.z;

        // 가로 강제 스크롤
        if (isForcrScrollX)
        {
            x = transform.position.x + (forceScrollSpeedX * Time.deltaTime);

        }
        // 가로방향 동기화
        if (x < leftLimit)
        {
            x = leftLimit;

        }
        else if (x > rightLimit)
        {
            x = rightLimit;
        }

        // 세로 강제 스크롤
        if (isForcrScrollY)
        {
            x = transform.position.y + (forceScrollSpeedY * Time.deltaTime);

        }


        // 세로방향 동기화
        if (y < bottomLimit)
        {
            y = bottomLimit;
        }
        else if (y < topLimit)
        {
            y = topLimit;
        }

        // 현재의 카메라 위치를 Vector3로 표현
        Vector3 vector3 = new Vector3(x, y, z);
        // 카메라의 위치를 설정한 값으로 적용
        transform.position = vector3;

        // 서브 스크린 작동
        if (subScreen != null)
        {
            y = subScreen.transform.position.y;
            z = subScreen.transform.position.z;
            Vector3 v = new Vector3(x * 0.5f, y, z);
            subScreen.transform.position = v;
        }

    }
}
