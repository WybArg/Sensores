using UnityEngine;

#if ENABLE_INPUT_SYSTEM 
using UnityEngine.InputSystem;
#endif

public class Character : MonoBehaviour
{
    public float speed;
    private bool getUp;
    public StarterAssetsInputs _input;
    [Space]
    public float lengthRay;
    private bool minDistanceGetUp;
    [Space]
    public Animator myAnima;
    public string BendDownName;
    public string BendUpName;

    void Update()
    {
        Move();
        Bend();
        RaycastMinDistanceGetUp();
    }


    private void Move()
    {
        if (_input.move != Vector3.zero)
        {
            transform.Translate(_input.move.normalized * speed * Time.deltaTime);
        }
    }


    private void Bend()
    {
        if (_input.bend)
        {
            if (!getUp)
            {
                myAnima.SetTrigger(BendDownName);
            }
            
            getUp = true;
        }
        else if (getUp && minDistanceGetUp)
        {
            myAnima.SetTrigger(BendUpName);

            getUp = false;
            _input.bend = false;
        }
    }


    public void RaycastMinDistanceGetUp()
    {
        Ray myRay = new Ray(this.transform.position, this.transform.up);

        if (Physics.Raycast(myRay,lengthRay))
        {
            minDistanceGetUp = false;
        }
        else
        {
            minDistanceGetUp = true;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(this.transform.position, this.transform.up* lengthRay);
    }
}

