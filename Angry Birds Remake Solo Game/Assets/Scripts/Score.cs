using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor.UI;

public class Score : MonoBehaviour
{
    /*TextMeshProUGUI scoreText;
    GameSessions myGameSessions; 

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        myGameSessions = FindObjectOfType<GameSessions>();
    }

    void Update()
    {
        scoreText.text = myGameSessions.GetScore().ToString();
    }*/

    public static Score instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    int score = 0;
    int highscore = 0;


    private void Awake()
    {
        instance = this;
        SetupSingleton();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0); //starts saving of highscore
        scoreText.text = "Score: " + score.ToString();
        highscoreText.text = "Highscore: " + highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetupSingleton()
    {
        if (FindObjectsOfType<Score>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void AddPoint(int pointValue)
    {
        score = score + pointValue;
        scoreText.text = score.ToString();
        //score += 1;
        scoreText.text = "Score: " + score.ToString();
        if (highscore < score)
        {
           PlayerPrefs.SetInt("highscore", score); //this is saving the highscore in player storage (PlayerPrefs)
        }
    }

    public void ResetHighScore()
    {
        // on home page reset highscore
    }

}
