using System.Collections;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public GameObject monsterPrefab;
    public int monsterCount = 1;
    private bool hasSpawned = false;
    private GameObject currentMonster;

    void Start()
    {
        SpawnMonster();


    }

    void SpawnMonster()
    {
        // 처음 시작할 때 한 번만 몬스터를 생성
        for (int i = 0; i < monsterCount; i++)
        {
            Skeleton.live = true; // 몬스터는 처음부터 살아있는 상태로 설정
            currentMonster = Instantiate(monsterPrefab, transform.position, Quaternion.identity);  // 몬스터 생성
        }
    }

    void Update()
    {
        if (!hasSpawned && APlayerController.state != "Playing" && Skeleton.live == false)
        {
            hasSpawned = true; // 중복 실행 방지
            StartCoroutine(SpawnMonsterWithDelay());


        }
        else if (!hasSpawned && APlayerController.state != "Playing" && Skeleton.live == true)
        {
            Destroy(currentMonster, 1f);
            hasSpawned = true;
            StartCoroutine(SpawnMonsterWithDelay());

        }

    }

    IEnumerator SpawnMonsterWithDelay()
    {
        if (currentMonster != null)
        {
            Destroy(currentMonster, 1f);

        }

        yield return new WaitForSeconds(2f); // 2초 대기
        for (int i = 0; i < monsterCount; i++)
        {
            Skeleton.live = true;
            currentMonster = Instantiate(monsterPrefab, transform.position, Quaternion.identity);
        }

        hasSpawned = false;
    }
}
