using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausaMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    private bool isPaused;

    public static PausaMenu Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else 
        {
            Instance = this;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UpdateGameState();
            ShowPanelPause();
        }
        
    }
    private void UpdateGameState()
    {
        isPaused = !isPaused;

        if (isPaused)
        {

            Time.timeScale = 0f;

        }
        else 
        {

           Time.timeScale = 1f;
        
        }
    }

    private void ShowPanelPause()
    {

        if (isPaused)
        {
            pausePanel.SetActive(true);
        }
        else 
        {
            pausePanel.SetActive(false);
        }
    }

}
