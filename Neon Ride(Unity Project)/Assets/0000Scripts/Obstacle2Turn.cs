/*
 * Obstacle 2 Turn
 * NEON RIDE
 * 
 * By: Szymon Kokot
 * Last Modification: 08/04/21
 * 
 * Script is meant to rotate an obstacle.
 */
using UnityEngine;

public class Obstacle2Turn : MonoBehaviour
{
    public float obsRot;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(obsRot, 0, 0);
    }
}
