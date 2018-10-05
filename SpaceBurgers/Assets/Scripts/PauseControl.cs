using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseControl : MonoBehaviour {

    [SerializeField]
    GameObject pausePanel;

    [SerializeField]
    GameObject gameOverPanel;

   // GameObject plate;

    private void Start()
    {
//        plate = GameObject.FindGameObjectWithTag("Lautanen");
    }


    public void PauseGame(Button btn)
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void GoToMenuScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;

    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
