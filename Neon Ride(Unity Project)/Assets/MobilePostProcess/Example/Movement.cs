using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector3 movementVector;
    void Update()
    {
        transform.position += movementVector * Time.deltaTime; 
    }
}
