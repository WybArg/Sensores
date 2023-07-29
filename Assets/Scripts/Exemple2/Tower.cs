using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float speedRotate;
    public Transform positionRay;
    public float lengthdRay;
    [Space]
    public GameObject missile;
    public Transform positionMissile;
    public float delayMissile;
    private bool missileAvailable = true;

    void Update()
    {
        RotateTower();

        Ray myRay = new Ray(positionRay.position, transform.forward);
        RaycastHit myHit;

        if (Physics.Raycast(myRay, out myHit, lengthdRay))
        {
            if (missileAvailable)
            {
                CreateMissile();
                Invoke(nameof(MissileAvailable), delayMissile);
                missileAvailable = false;
            }
        }

    }

    public void RotateTower()
    {
        this.transform.Rotate(0, speedRotate * Time.deltaTime, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(positionRay.position, transform.forward * lengthdRay);
    }

    public void CreateMissile()
    {
        Instantiate(missile, positionMissile.position, positionMissile.rotation);
    }

    public void MissileAvailable()
    {
        missileAvailable = true;
    }


}
