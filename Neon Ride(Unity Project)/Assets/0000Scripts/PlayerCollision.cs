/*
 * Character Collision
 * NEON RIDE
 * 
 * By: Szymon Kokot
 * Last Modification: 14/03/21
 * 
 * Cheks character collisions and adds points, or end game
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public Text scoreText; //"Score:\n" or  "Previous score:\n" 
    public Text pointText; // Points number
    int points;

    public Animator animMan; //animations

    public GameController controller;

    private void Start()
    {
        points = 0;
        scoreText.text = "Previous score\n";
        pointText.text = "" + PlayerPrefs.GetInt("previous");
    }
    //When collision detected
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Obstacle":
                controller.GameOver();
                PlayerPrefs.SetInt("previous", points);
                Start();
                break;
            case "Gratification1":
                if (PlayerPrefs.GetInt("state") == 1)
                {
                    points++;
                    scoreText.text = "Score:";
                    pointText.text = "" + points;
                    animMan.Play("anim+1");
                }
                break;
            case "Final":
                controller.GameWin();
                PlayerPrefs.SetInt("previous", points);
                Start();
                break;
            default:
                if (PlayerPrefs.GetInt("state") == 1)
                {
                    points += 2;
                    scoreText.text = "Score:";
                    pointText.text = "" + points;
                    animMan.Play("anim+3");
                }
                break;
        }

        if (points >= PlayerPrefs.GetInt("levelScore"))
            PlayerPrefs.SetInt("final", 1);
    }
}
