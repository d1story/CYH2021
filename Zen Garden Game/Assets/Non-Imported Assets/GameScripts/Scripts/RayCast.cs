using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public Vector3 R(Vector3 To, Vector3 des)
    {
        //check if there is some thing in the way
        RaycastHit temp; 
        Debug.DrawRay(transform.position, des, Color.white);
        if (Physics.Raycast(transform.position, des, out temp))
        {
            To = temp.point;
            Debug.DrawRay(transform.position, To - transform.position, Color.red);
            Debug.Log(temp.collider.gameObject.name);
        }
        return To;
    }
}
