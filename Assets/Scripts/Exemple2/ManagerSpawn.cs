using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSpawn : MonoBehaviour
{
    public int countEnemy;
    private int count = 1;
    public GameObject enemy;
    private Vector3 positionEnemy;


    void Update()
    {
        if (count <= countEnemy)
        {
            CreateEnemy();
            count++;
        }
    }

    public void CreateEnemy()
    {
        positionEnemy = Random.insideUnitCircle.normalized * 5;
        positionEnemy.z = positionEnemy.y;
        positionEnemy.y = 0;

        Instantiate(enemy, positionEnemy, Quaternion.identity);
    }



}
