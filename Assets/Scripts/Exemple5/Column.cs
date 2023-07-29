using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    private Vector3 positionRay;
    private RaycastHit myHit;

    private void Start()
    {
        PositionRaycast();
    }

    void Update()
    {
        Ray myRay = new Ray(positionRay, Vector3.left);
        if (Physics.Raycast(myRay, out myHit))
        {
            print("Distance: " + myHit.distance);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(positionRay, Vector3.left * myHit.distance);
    }

    public void PositionRaycast()
    {
        positionRay = transform.position;
        positionRay.x -= transform.localScale.x / 2;
    }


}
