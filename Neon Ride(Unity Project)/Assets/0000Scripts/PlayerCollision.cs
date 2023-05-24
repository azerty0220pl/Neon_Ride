/*
 * Character Collision
 * NEON RIDE
 * 
 * By: Szymon Kokot
 * Last Modification: 17/04/21
 * 
 * Cheks character collisions and adds points, or end game
 */
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public Text scoreText; //"Score:\n" or  "Previous score:\n" 
    public Text pointText; // Points number
    int points;
    int realPoints;
    //private int adCounter = 0;
    public int perfectCounter = 0; // Perfects in a row

    public Animator animMan1; //animations +1
    public Animator animMan2; //animations +3
    public Animator animMan3; //animation x2

    public ParticleSystem partSys1;
    public ParticleSystem partSys2;
    public ParticleSystem partSys4;

    public GameController controller;
    //public adsMan adsManager;

    private void Start()
    {
        points = 0;
        realPoints = 0;
        perfectCounter = 0;
        scoreText.text = "Previous score\n";
        pointText.text = "" + PlayerPrefs.GetInt("previous");
    }
    //When collision detected
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Obstacle":
                /*if (PlayerPrefs.GetInt("state") == 1)
                    adCounter++;*/
                controller.GameOver();
                PlayerPrefs.SetInt("previous", points);
                /*if (adCounter >= 3)
                {
                    adsManager.showAd();
                    adCounter = 0;
                }*/
                //Analytics.CustomEvent("GameOver" + PlayerPrefs.GetInt("level"));
                Start();
                break;
            case "Final":
                controller.GameWin();
                PlayerPrefs.SetInt("previous", points);
                //Analytics.CustomEvent("GameWin" + PlayerPrefs.GetInt("level"));
                realPoints = 0;
                pointText.text = "" + points;
                partSys4.Play();
                break;
        }

        if (realPoints >= PlayerPrefs.GetInt("levelScore"))
            PlayerPrefs.SetInt("final", 1);
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Gratification1":
                if (PlayerPrefs.GetInt("state") == 1)
                {
                    points++;
                    realPoints++;
                    perfectCounter -= perfectCounter == 0 ? 0 : 1;
                    if (perfectCounter >= 5)
                    {
                        points += 1;
                        realPoints += 1;
                        animMan3.Play("x2");
                        partSys2.Play();
                    }
                    pointText.text = "" + points;

                    animMan1.Play("anim+1");
                    partSys1.Play();
                }
                break;
            default:
                if (PlayerPrefs.GetInt("state") == 1)
                {
                    perfectCounter += 2;
                    points += 2;
                    realPoints += 2;
                    if (perfectCounter >= 5)
                        points += 2;

                    pointText.text = "" + points;
                    animMan1.StopPlayback();
                    animMan2.Play("anim+3");
                }
                break;
        }
    }
}
