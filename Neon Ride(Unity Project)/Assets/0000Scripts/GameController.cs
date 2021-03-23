/*
 * Game Controller
 * NEON RIDE
 * 
 * By: Szymon Kokot
 * Last Modification: 14/03/21
 * 
 * General game controller.
 * Game Statuses:
 *  -1 - Game over
 *  0 - Idle
 *  1 - In game
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Tunel tunel;
    public ObstaclesManager obsMan;

    public GameObject mainPanel; //main menu
    public GameObject gamePanel; //contains game controls
    public GameObject overPanel; //game over screen

    private void Start()
    {
        PlayerPrefs.SetInt("state", 0);
        LoadLevel(PlayerPrefs.GetInt("level"));
    }

    //Called by button from Main Menu
    public void StartGame()
    {
        mainPanel.SetActive(false);
        gamePanel.SetActive(true);

        PlayerPrefs.SetInt("state", 1);
    }
    //Called from PlayerCollision class
    public void GameOver()
    {
        gamePanel.SetActive(false);
        overPanel.SetActive(true);
        LoadLevel(-1);

        PlayerPrefs.SetInt("state", -1);
    }
    //Called from PlayerCollision class
    public void GameWin()
    {
        gamePanel.SetActive(false);
        mainPanel.SetActive(true);
        obsMan.DisableAll();
        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
        LoadLevel(PlayerPrefs.GetInt("level"));

        PlayerPrefs.SetInt("state", 0);
    }
    //Called by button from game over menu
    public void RestartGame()
    {
        overPanel.SetActive(false);
        mainPanel.SetActive(true);
        LoadLevel(PlayerPrefs.GetInt("level"));
        obsMan.DisableAll();

        PlayerPrefs.SetInt("state", 0);
    }

    // Changes speed, earnings and obstacle chances
    void LoadLevel(int level)
    {
        switch (level)
        {
            case -1:
                tunel.SetSpeed(0);
                break;
            case 0:
                tunel.SetSpeed(8);
                PlayerPrefs.SetInt("levelScore", 25);
                break;
            case 1:
                tunel.SetSpeed(9);
                PlayerPrefs.SetInt("levelScore", 25);
                break;
            case 2:
                tunel.SetSpeed(10);
                PlayerPrefs.SetInt("levelScore", 50);
                break;
            case 3:
                tunel.SetSpeed(11);
                PlayerPrefs.SetInt("levelScore", 75);
                break;
            case 4:
                tunel.SetSpeed(12);
                PlayerPrefs.SetInt("levelScore", 75);
                break;
            case 5:
                tunel.SetSpeed(13);
                PlayerPrefs.SetInt("levelScore", 75);
                break;
            case 6:
                tunel.SetSpeed(14);
                PlayerPrefs.SetInt("levelScore", 100);
                break;
            case 7:
                tunel.SetSpeed(15);
                PlayerPrefs.SetInt("levelScore", 100);
                break;
            case 8:
                tunel.SetSpeed(16);
                PlayerPrefs.SetInt("levelScore", 125);
                break;
            case 9:
                tunel.SetSpeed(17);
                PlayerPrefs.SetInt("levelScore", 125);
                break;
            case 10:
                tunel.SetSpeed(18);
                PlayerPrefs.SetInt("levelScore", 150);
                break;
        }
    }
}
