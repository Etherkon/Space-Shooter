using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public GameObject tie;
    public GameObject destroyer;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public float endWait;

    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;

    private bool gameOver;
    private bool restart;
    private int score;
    private float counter;
    private int difficulty;
    private float wait;

    void Start ()
    {
        wait = spawnWait;
        difficulty = 0;
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        counter = 0;
        UpdateScore ();
        StartCoroutine (SpawnWaves ());
    }

    void Update ()
    {
        if(difficulty == 0) { wait = spawnWait; }
        else if(difficulty == 1) { wait = 3*spawnWait/4; }
        else if(difficulty == 2) { wait = 2*spawnWait/3; }
        else if(difficulty == 3) { wait = spawnWait/2; }
        else if(difficulty == 4) { wait = spawnWait/3; }

        if (restart)
        {
            StartCoroutine (ends ());
            
        }
    }

    IEnumerator ends () {
          yield return new WaitForSeconds (endWait);
          Application.LoadLevel (Application.loadedLevel);
    }

    IEnumerator SpawnWaves ()
    {  
        yield return new WaitForSeconds (startWait);
	while (true)
        {
               // 0-6,7-11,12-13

                counter = Random.Range (0, 13);
                Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;

                 // Meteor
               if(counter < 7) {     	   	  	  
         	  Instantiate (hazard, spawnPosition, spawnRotation);
                  yield return new WaitForSeconds (wait);}

                  // Tie
                
                else if(counter > 6 & counter < 12) {   
                  Instantiate (tie, spawnPosition,  Quaternion.Euler(0, 180, 0));
                  yield return new WaitForSeconds (wait); }

		  // Star D
              
                else if(counter > 11) { 
                  Instantiate (destroyer, spawnPosition,  Quaternion.Euler(0, 0, 0));
                  yield return new WaitForSeconds (wait*4); }

            if (gameOver)
            {
                restartText.text = "";
                restart = true;
                break;
            }
           
    	}
    }

    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore ();
        if(score > 10000) { difficulty = 4;}
        else if(score > 6000) { difficulty = 3;}
        else if(score > 3000) { difficulty = 2;}
        else if(score > 1000) { difficulty = 1;}
    }

    void UpdateScore ()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver ()
    {
        gameOverText.text = "Game Over !";
        gameOver = true;
    }
    
}