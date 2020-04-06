using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float Spawnwait;
    public float StartWait;
    public float WaveWait;

    public Text ScoreText;
    public Text RestartText;
    public Text GameOverText;

    private bool Game_Over;
    private bool Restart;
    private int Score;


    void Start()
    {
        Game_Over = false;
        Restart = false;
        RestartText.text = "";
        GameOverText.text = "";
        Score = 0;
        UpdateScore();
        StartCoroutine(spawnWaves());
    }
    void Update()
    {
    if (Restart)
        {
        if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SpaceShooter");
            }
        }
        if (Input.GetKey("escape")) 
        {
            Application.Quit();
        }
    }
    IEnumerator spawnWaves()
    {
        yield return new WaitForSeconds(StartWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(Spawnwait);
            }
            yield return new WaitForSeconds(WaveWait);

            if (Game_Over)
            {
                RestartText.text = "Press 'R' for Restart!";
                Restart = true;
                break;
            }
        }   
    }
    public void AddScore(int newScoreValue)
    {
        Score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Score: " + Score;
    }
    public void GameOver()
    {
        GameOverText.text = "Game Over!";
        Game_Over = true;
    }
}
