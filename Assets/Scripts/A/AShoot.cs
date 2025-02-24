using System;
using System.Collections.Generic;
using UnityEngine;

public class AShoot : MonoBehaviour
{
    public float delay = 0.25f;
    public GameObject bowPrefab; // Ȱ
    public GameObject arrowPrefab;
    public Transform pos;
     public enum anime { AAttack }

    bool inAttack = false; // ���� ������� Ȯ��
    GameObject bowObject;



    void Start()
    {

        Vector3 position = transform.position;
        bowObject = Instantiate(bowPrefab, position, Quaternion.identity);
        // Ȱ ������Ʈ�� �θ�� �÷��̾��Դϴ�.
        bowObject.transform.SetParent(transform);

    }

  
    void Update()
    {


        if (inAttack == false && Input.GetKeyDown(KeyCode.LeftControl))        
        {
            inAttack = true; // ���� ���·� ��ȯ
            Instantiate(arrowPrefab, pos.position, transform.rotation);            
            Invoke("AttackChange", delay);
        }


    }




    public void AttackChange()
    {
        inAttack = false;
    }


}
