/*
 * Obstacles
 * NEON RIDE
 * 
 * By: Szymon Kokot
 * Last Modification: 13/03/21
 * 
 * Methods to control obstacles from ONE section.
 */
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public GameObject[] obstacles;

    public void HideAll()
    {
        for (int i = 0; i < obstacles.Length; i++)
            obstacles[i].SetActive(false);
    }
    // Activates a random Obstacle (excluding final) and randomly rotates it
    public void ActivateRandom()
    {
        int x = Random.Range(0, 100) % (obstacles.Length - 1); //Obstacles length and -1 to avoid activating final
        obstacles[x].SetActive(true);
        obstacles[x].transform.eulerAngles = new Vector3(Random.Range(0, 180), 0, 0);
    }
    // Activates final gameobject on game win
    public void ActivateFinal()
    {
        obstacles[obstacles.Length - 1].SetActive(true);
    }
}
