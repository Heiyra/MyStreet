using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Text scoretxt,bestscoretxt,lifetxt;

    public GameObject PlayButton;

    public int life = 3;

    public int score;

    public int bestscore;


    public bool isDeath;

    public bool unDeath;

    private void Awake()
    {
        Instance = this;

        life = 3;
        score = 0;
        isDeath = false;

        Time.timeScale = 0;
        PlayButton.SetActive(true);
        bestscore = PlayerPrefs.GetInt("BestScore");
        scoretxt.color = Color.white;
    }
    private void Update()
    {
        scoretxt.text = "Score : " + score.ToString();
        bestscoretxt.text ="BestScore : " + bestscore.ToString();
        lifetxt.text = "Life : " + life.ToString();

        if (score > bestscore)
        {
            scoretxt.color = Color.cyan;
        }
        if (life <= 0)
        {
            isDeath = true;
            
            if (score > bestscore)
            {
                bestscore = score;
                SaveBestScore();
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void PlayBut()
    {
        Time.timeScale = 1;
        PlayButton.SetActive(false);
    }

    public void ExitBut()
    {
        Application.Quit();
    }
    public void SaveBestScore()
    {
        PlayerPrefs.SetInt("BestScore", bestscore);
        PlayerPrefs.Save();
    }
}
