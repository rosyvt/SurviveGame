using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Makes sure that the billboard always points towards the camera
public class Billboard : MonoBehaviour
{
    public Transform cam;

    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
