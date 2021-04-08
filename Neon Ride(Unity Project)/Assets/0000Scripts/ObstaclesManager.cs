/*
 * Obstacles Manager
 * NEON RIDE
 * 
 * By: Szymon Kokot
 * Last Modification: 13/03/21
 * 
 * Methods to control obstacles from ALL section.
 */
using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
    public Obstacles[] obstacles;

    //Method called from Tunel class
    public void ChangeObstacle(int num)
    {
        obstacles[num].HideAll();
        // If goal points of the level is reached, final will be activated
        if (PlayerPrefs.GetInt("final") == 0)
            obstacles[num].ActivateRandom();
        else
        {
            PlayerPrefs.SetInt("final", 0);
            obstacles[num].ActivateFinal();
        }
    }

    //Disables all obstacles after game over. Called from GameController class
    public void DisableAll()
    {
        for (int i = 0; i < obstacles.Length; i++)
            obstacles[i].HideAll();
    }
}
