using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerBeam : MonoBehaviour
{
    public float speedRotate;
    public float lenghtRay;
    public GameObject laserParticle;


    private RaycastHit myHit;
    private bool createParticle=true;
    private GameObject particle;


    void Update()
    {
        RotateLayer();

        Ray myRay = new Ray(this.transform.position, this.transform.forward);
        

        if(Physics.Raycast(myRay,out myHit, lenghtRay))
        {
            if (createParticle) CreateLaserParticle();
            particle.transform.position = myHit.point;
        }
        else if (particle != null)
        {
            Destroy(particle);
            createParticle = true;
        }

    }


    public void RotateLayer()
    {
        this.transform.Rotate(0, speedRotate * Time.deltaTime, 0);
    }

    public void CreateLaserParticle()
    {
        particle = Instantiate(laserParticle, myHit.point, Quaternion.identity);
        createParticle = false;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(this.transform.position, this.transform.forward * lenghtRay);
    }


}
