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

    public GameObject PauseButton;
    public GameObject UnPauseButton;
   // GameObject plate;

    private void Start()
    {
//        plate = GameObject.FindGameObjectWithTag("Lautanen");
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if(Input.GetKeyDown (KeyCode.Escape)){
            
            PauseButton.GetComponent<Button>().onClick.Invoke();
        }
    }

    public void PauseGame()
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
