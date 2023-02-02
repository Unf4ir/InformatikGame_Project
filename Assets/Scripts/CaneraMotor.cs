using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaneraMotor : MonoBehaviour
{
    // Tutorial: https://www.youtube.com/watch?v=b8YUfee_pzc (ab: 55:42)
    public Transform lookAt;
    public float boundX = 0.05f;
    public float boundZ = 0.05f;

    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;
        //This is to check if we are inside the bounds on the x axis
        float deltaX = lookAt.position.x - transform.position.x;
        if(deltaX > boundX || deltaX <-boundX)
        {
            if (transform.position.x < lookAt.position.x)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }

        }

        //This is to check if we are inside the bounds on the y axis
        float deltaZ = lookAt.position.z - transform.position.z;
        if (deltaZ > boundZ || deltaZ < -boundZ)
        {
            if (transform.position.z < lookAt.position.z)
            {
                delta.z = deltaZ - boundZ;
            }
            else
            {
                delta.z = deltaZ + boundZ;
            }

        }
        transform.position += new Vector3(delta.x, 0 , deltaZ);
    }
}
