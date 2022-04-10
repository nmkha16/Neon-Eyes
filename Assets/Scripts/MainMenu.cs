using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public GameObject aboutUs, mainMenu, difficultyMenu;
    void Start()
    {
        aboutUs.SetActive(false);
        difficultyMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void AboutUsMenu()
    {
        aboutUs.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void BackMenu()
    {
        aboutUs.SetActive(false);
        mainMenu.SetActive(true);
        difficultyMenu.SetActive(false);
    }

    public void chooseDifficulty()
    {
        difficultyMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void easy()
    {
        PlayerPrefs.SetInt("difficulty", 3);
        PlayGame();
    }

    public void hard()
    {
        PlayerPrefs.SetInt("difficulty", 5);
        PlayGame();
    }

    public void veryHard()
    {
        PlayerPrefs.SetInt("difficulty", 7);
        PlayGame();
    }

    public void impossible()
    {
        PlayerPrefs.SetInt("difficulty", 11);
        PlayGame();
    }
}
