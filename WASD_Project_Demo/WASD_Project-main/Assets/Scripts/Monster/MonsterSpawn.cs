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
        // ó�� ������ �� �� ���� ���͸� ����
        for (int i = 0; i < monsterCount; i++)
        {
            Skeleton.live = true; // ���ʹ� ó������ ����ִ� ���·� ����
            currentMonster = Instantiate(monsterPrefab, transform.position, Quaternion.identity);  // ���� ����
        }
    }

    void Update()
    {
        if (!hasSpawned && APlayerController.state != "Playing" && Skeleton.live == false)
        {
            hasSpawned = true; // �ߺ� ���� ����
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

        yield return new WaitForSeconds(2f); // 2�� ���
        for (int i = 0; i < monsterCount; i++)
        {
            Skeleton.live = true;
            currentMonster = Instantiate(monsterPrefab, transform.position, Quaternion.identity);
        }

        hasSpawned = false;
    }
}
