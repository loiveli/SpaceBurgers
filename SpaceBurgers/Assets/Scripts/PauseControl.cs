using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseControl : MonoBehaviour {

    [SerializeField]
    GameObject pausePanel;


    public void Test(Button btn)
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void GoToMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        
    }
}
