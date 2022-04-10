using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class InGameMenu : MonoBehaviour
{
    [SerializeField] public GameObject endMenu, pauseMenu;
    public TMP_Text highScore;
    // Start is called before the first frame update
    void Start()
    {
        endMenu.SetActive(false);
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame();
        }
    }

    // Update is called once per frame
    public void endGame()
    {
        endMenu.SetActive(true);
        Time.timeScale = 0;
        if (PlayerPrefs.GetInt("highscore") < ScoreSystem.instance.getScore())
        {
            PlayerPrefs.SetInt("highscore", ScoreSystem.instance.getScore());
        }
        highScore.text = "Score: " + ScoreSystem.instance.getScore().ToString() + 
            "\nHighest score: " + PlayerPrefs.GetInt("highscore").ToString();

    }

    private void pauseGame()
    {
        if (endMenu.activeInHierarchy) { return; }
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void resumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void goToMenu()
    {
        Time.timeScale = 1f;
        //SceneManager.UnloadScene(sceneBuildIndex: 1);
        SceneManager.LoadScene(sceneBuildIndex: 0);

    }

    public void restartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
}
