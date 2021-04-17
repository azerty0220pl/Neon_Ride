/*
 * Game Controller
 * NEON RIDE
 * 
 * By: Szymon Kokot
 * Last Modification: 17/04/21
 * 
 * General game controller.
 * Game Statuses:
 *  -1 - Game over
 *  0 - Idle
 *  1 - In game
 */
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Tunel tunel;
    public ObstaclesManager obsMan;
    public InsideMaterialChanger insideChanger;

    public GameObject mainPanel; //main menu
    public GameObject gamePanel; //contains game controls
    public GameObject overPanel; //game over screen

    //Score texts
    public Text scoreText;
    public Text pointText;

    private void Start()
    {
        PlayerPrefs.SetInt("state", 0);
        LoadLevel(PlayerPrefs.GetInt("level"));

        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 120;
    }

    //Called by button from Main Menu
    public void StartGame()
    {
        mainPanel.SetActive(false);
        gamePanel.SetActive(true);

        scoreText.text = "Score:";
        pointText.text = "0";

        PlayerPrefs.SetInt("state", 1);
    }
    //Called from PlayerCollision class
    public void GameOver()
    {
        gamePanel.SetActive(false);
        overPanel.SetActive(true);
        LoadLevel(-1);

        PlayerPrefs.SetInt("state", -1);
        PlayerPrefs.SetInt("final", 0);
    }
    //Called from PlayerCollision class
    public void GameWin()
    {
        obsMan.DisableAll();
        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
        LoadLevel(PlayerPrefs.GetInt("level"));
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
                PlayerPrefs.SetInt("levelScore", 15);
                insideChanger.changeColor(new Color(1, 1, 1, 1));
                break;
            case 1:
                tunel.SetSpeed(9);
                PlayerPrefs.SetInt("levelScore", 20);
                insideChanger.changeColor(new Color(0.75f, 1, 1, 1));
                break;
            case 2:
                tunel.SetSpeed(10);
                PlayerPrefs.SetInt("levelScore", 20);
                insideChanger.changeColor(new Color(0.5f, 1, 1, 1));
                break;
            case 3:
                tunel.SetSpeed(10);
                PlayerPrefs.SetInt("levelScore", 25);
                insideChanger.changeColor(new Color(0.25f, 1, 1, 1));
                break;
            case 4:
                tunel.SetSpeed(10);
                PlayerPrefs.SetInt("levelScore", 25);
                insideChanger.changeColor(new Color(0, 1, 1, 1));
                break;
            case 5:
                tunel.SetSpeed(10);
                PlayerPrefs.SetInt("levelScore", 25);
                insideChanger.changeColor(new Color(0, 0.75f, 1, 1));
                break;
            case 6:
                tunel.SetSpeed(10.5f);
                PlayerPrefs.SetInt("levelScore", 30);
                insideChanger.changeColor(new Color(0, 0.5f, 1, 1));
                break;
            case 7:
                tunel.SetSpeed(10.5f);
                PlayerPrefs.SetInt("levelScore", 30);
                insideChanger.changeColor(new Color(0, 0.25f, 1, 1));
                break;
            case 8:
                tunel.SetSpeed(11);
                PlayerPrefs.SetInt("levelScore", 40);
                insideChanger.changeColor(new Color(0, 0, 1, 1));
                break;
            case 9:
                tunel.SetSpeed(11);
                PlayerPrefs.SetInt("levelScore", 50);
                insideChanger.changeColor(new Color(0.25f, 0, 1, 1));
                break;
            case 10:
                tunel.SetSpeed(11);
                PlayerPrefs.SetInt("levelScore", 60);
                insideChanger.changeColor(new Color(0.5f, 0, 1, 1));
                break;
            case 11:
                tunel.SetSpeed(11);
                PlayerPrefs.SetInt("levelScore", 70);
                insideChanger.changeColor(new Color(0.75f, 0, 1, 1));
                break;
            case 12:
                tunel.SetSpeed(11.5f);
                PlayerPrefs.SetInt("levelScore", 80);
                insideChanger.changeColor(new Color(1, 0, 1, 1));
                break;
            case 13:
                tunel.SetSpeed(11.5f);
                PlayerPrefs.SetInt("levelScore", 90);
                insideChanger.changeColor(new Color(1, 0, 0.75f, 1));
                break;
            case 14:
                tunel.SetSpeed(12);
                PlayerPrefs.SetInt("levelScore", 100);
                insideChanger.changeColor(new Color(1, 0, 0.5f, 1));
                break;
            case 15:
                tunel.SetSpeed(12);
                PlayerPrefs.SetInt("levelScore", 100);
                insideChanger.changeColor(new Color(1, 0, 0.25f, 1));
                break;
            case 16:
                tunel.SetSpeed(12);
                PlayerPrefs.SetInt("levelScore", 110);
                insideChanger.changeColor(new Color(1, 0, 0, 1));
                break;
            case 17:
                tunel.SetSpeed(13);
                PlayerPrefs.SetInt("levelScore", 110);
                insideChanger.changeColor(new Color(1, 0.25f, 0, 1));
                break;
            case 18:
                tunel.SetSpeed(13);
                PlayerPrefs.SetInt("levelScore", 110);
                insideChanger.changeColor(new Color(1, 0.5f, 0, 1));
                break;
            case 19:
                tunel.SetSpeed(13);
                PlayerPrefs.SetInt("levelScore", 125);
                insideChanger.changeColor(new Color(1, 0.75f, 0, 1));
                break;
            case 20:
                tunel.SetSpeed(14);
                PlayerPrefs.SetInt("levelScore", 140);
                insideChanger.changeColor(new Color(1, 1, 0, 1));
                break;
            case 21:
                tunel.SetSpeed(14);
                PlayerPrefs.SetInt("levelScore", 140);
                insideChanger.changeColor(new Color(0.75f, 1, 0, 1));
                break;
            case 22:
                tunel.SetSpeed(14);
                PlayerPrefs.SetInt("levelScore", 150);
                insideChanger.changeColor(new Color(0.5f, 1, 0, 1));
                break;
            case 23:
                tunel.SetSpeed(15);
                PlayerPrefs.SetInt("levelScore", 150);
                insideChanger.changeColor(new Color(0.25f, 1, 0, 1));
                break;
            case 24:
                tunel.SetSpeed(15);
                PlayerPrefs.SetInt("levelScore", 150);
                insideChanger.changeColor(new Color(0, 1, 0, 1));
                break;
            case 25:
                tunel.SetSpeed(15);
                PlayerPrefs.SetInt("levelScore", 175);
                insideChanger.changeColor(new Color(0.25f, 1, 0, 1));
                break;
            case 26:
                tunel.SetSpeed(16);
                PlayerPrefs.SetInt("levelScore", 175);
                insideChanger.changeColor(new Color(0.5f, 1, 0, 1));
                break;
            case 27:
                tunel.SetSpeed(17);
                PlayerPrefs.SetInt("levelScore", 175);
                insideChanger.changeColor(new Color(0.75f, 1, 0.25f, 1));
                break;
            case 28:
                tunel.SetSpeed(18);
                PlayerPrefs.SetInt("levelScore", 175);
                insideChanger.changeColor(new Color(1, 1, 0.5f, 1));
                break;
            case 29:
                tunel.SetSpeed(19);
                PlayerPrefs.SetInt("levelScore", 175);
                insideChanger.changeColor(new Color(1, 1, 0.75f, 1));
                break;
            case 30:
                tunel.SetSpeed(20);
                PlayerPrefs.SetInt("levelScore", 200);
                insideChanger.changeColor(new Color(1, 1, 1, 1));
                break;
            default:
                tunel.SetSpeed(25);
                PlayerPrefs.SetInt("levelScore", 2002);
                insideChanger.changeColor(new Color(1, 1, 1, 1));
                break;
        }
    }
}
