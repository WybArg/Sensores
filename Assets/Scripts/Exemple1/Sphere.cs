using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public Transform positionRay;
    public float speed;
    public LayerMask rayMaskInteraction;
    public float lenghtRay;
    public float height;
    void Update()
    {
        Move();

        Ray myRay = new Ray(positionRay.position, Vector3.down);
        RaycastHit myHit;

        if (Physics.Raycast(myRay,out myHit, lenghtRay, rayMaskInteraction))
        {
           float collisionPosition = myHit.point.y;

            Vector3 newPosition = new Vector3(transform.position.x, height + collisionPosition, transform.position.z);

            this.transform.position = newPosition;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(positionRay.position, Vector3.down* lenghtRay);
    }


    public void Move()
    {
        Vector3 position = Vector3.forward;
        this.transform.position += position * speed * Time.deltaTime;
    }

}
