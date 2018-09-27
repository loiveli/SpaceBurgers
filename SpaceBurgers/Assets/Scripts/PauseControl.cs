using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseControl : MonoBehaviour {

    [SerializeField]
    Button pauseButton;


    private void Start()
    {
        pauseButton = GameObject.FindGameObjectWithTag("PauseButton").GetComponent<Button>();
      
        pauseButton.onClick.AddListener(()=>Test());
    }

    public void Test()
    {
        Debug.Log("Button pressed");
    }
}
