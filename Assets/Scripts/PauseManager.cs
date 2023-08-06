using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseScreen;
    public Button resumeButton;
    public Button settingsButton;
    public Button exitButton;
    public Menu menuRef;
    public Manager managerRef;

    private bool isPaused = false;
    
    
    
    private void Start()
    {
        
        pauseScreen.SetActive(false);
        
    }
    
    
    
    public void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
                Debug.Log("Game has been resumed");
            }
            else
            {
                PauseGame();
                Debug.Log("Game has been paused");
            }
        }
    }
    private void PauseGame()
    {
        
        Time.timeScale = 0f; // Freeze the game
        managerRef.playerScoreText.enabled = false;
        managerRef.cpuScoreText.enabled = false;
        // Show the pause screen
        pauseScreen.SetActive(true);
        isPaused = true;
        Debug.Log("isPause = true");
    }
    public void ResumeGame()
    {
        
        pauseScreen.SetActive(false);
        // Resume normal time flow
        Time.timeScale = 1f;
        managerRef.playerScoreText.enabled = true;
        managerRef.cpuScoreText.enabled = true;
        isPaused = false;
        Debug.Log("isPause = false");

        // Hide the pause screen
       
    }
    public void OpenSettings()
    {
        menuRef.SelectSettings();
        Debug.Log("Settings button pressed");
    }
    public void ExitGame()
    {
        menuRef.ExitGame();
    }


}
