/*
 * Tunel
 * NEON RIDE
 * 
 * By: Szymon Kokot
 * Last modification: 14/03/21
 * 
 * Script attached to "Tunel" component. Responsible for advance in tunel and obstacle change if needed.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunel : MonoBehaviour
{
    //Rigidbodies of the tunel sections
    public Rigidbody[] rbs;

    //Obstacles will change with a method from this class 
    public ObstaclesManager obs;

    //Used in Update
    private int i = 0;

    //Changes speed of all tunel sections. Called from GameController class
    public void SetSpeed(int speed)
    {
        //speed == 0 iff game over; stops the tunel and makes it go back a little bit back.
        // if speed != 0; just changes speed of all tunel sections
        if (speed == 0)
        {
            Time.timeScale = 0;
            for (int i = 0; i < rbs.Length; i++)
                rbs[i].velocity = new Vector3(0, 0, 0);

            for (int i = 0; i < rbs.Length; i++)
                rbs[i].gameObject.transform.position = new Vector3(rbs[i].gameObject.transform.position.x + 0.7f, 0, 0);

            Time.timeScale = 1;
        }
        else
        {
            for (int i = 0; i < rbs.Length; i++)
                rbs[i].velocity = new Vector3(-speed, 0, 0);

        }
    }

    private void Update()
    {
        //Moves sections back when needed and changes obstacle if necessary
        if (rbs[i].gameObject.transform.position.x < -4)
        {
            rbs[i].gameObject.transform.position = new Vector3(rbs[i].gameObject.transform.position.x + 48, 0, 0);
            if(PlayerPrefs.GetInt("state") == 1)
                obs.ChangeObstacle(i);
            i++;
        }
        if (i > 5)
            i = 0;
        //Disables all obstacles on game win
        if (PlayerPrefs.GetInt("state") == 2)
        {
            obs.DisableAll();
            PlayerPrefs.SetInt("state", 0);
        }
    }
}
