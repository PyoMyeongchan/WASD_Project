using System;
using System.Collections.Generic;
using UnityEngine;

public class AShoot : MonoBehaviour
{
    public float delay = 0.25f;
    public GameObject bowPrefab; // 활
    public GameObject arrowPrefab;
    public Transform pos;
     public enum anime { AAttack }

    bool inAttack = false; // 공격 모드인지 확인
    GameObject bowObject;



    void Start()
    {

        Vector3 position = transform.position;
        bowObject = Instantiate(bowPrefab, position, Quaternion.identity);
        // 활 오브젝트의 부모는 플레이어입니다.
        bowObject.transform.SetParent(transform);

    }

  
    void Update()
    {


        if (inAttack == false && Input.GetKeyDown(KeyCode.LeftControl))        
        {
            inAttack = true; // 공격 상태로 전환
            Instantiate(arrowPrefab, pos.position, transform.rotation);            
            Invoke("AttackChange", delay);
        }


    }




    public void AttackChange()
    {
        inAttack = false;
    }


}
