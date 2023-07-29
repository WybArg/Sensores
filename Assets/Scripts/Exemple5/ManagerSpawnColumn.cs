using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSpawnColumn : MonoBehaviour
{
    public GameObject column;
    public int minWidthColumn;
    public int maxWidthColumn;
    public float sizePlatformInX;
    public int countColumn;
    private int count = 1;


    private void Update()
    {
        if (count <= countColumn)
        {
            CreateColumn();
            count++;
        }
    }

    public void CreateColumn()
    {
        Vector3 positionColumn = Vector3.zero;
        positionColumn.x = Random.Range(-sizePlatformInX, sizePlatformInX);

        GameObject prefabColumn = Instantiate(column, positionColumn, Quaternion.identity);

        int sizeInX = Random.Range(minWidthColumn, maxWidthColumn + 1);

        prefabColumn.transform.localScale = new Vector3(sizeInX, 1, 1);
    }




}
