/*
 * Obstacle 2 Turn
 * NEON RIDE
 * 
 * By: Szymon Kokot
 * Last Modification: 28/03/21
 * 
 * Script is meant to rotate an obstacle.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle2Turn : MonoBehaviour
{
    public float obsRot;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(obsRot * Time.deltaTime * 100, 0, 0);
    }
}
