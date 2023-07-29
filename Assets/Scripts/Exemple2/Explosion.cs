using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public LayerMask BurstMaskInteraction;
    public float radius;
    public float durationExplosion;

    void Start()
    {
        Collider[] myCol = Physics.OverlapSphere(this.transform.position, radius, BurstMaskInteraction);

        foreach (Collider enemy in myCol)
        {
            Destroy(enemy.gameObject);
        }

        Invoke(nameof(DestroyerGameObject), durationExplosion);
    }



    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }


    public void DestroyerGameObject()
    {
        Destroy(this.gameObject);
    }


}
