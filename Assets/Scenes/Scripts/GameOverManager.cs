using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject victoryPanel;
    
    public void ShowGameOver()
    {
        // Show the game over panel
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f; // Pause the game
            Debug.Log("Game Over!");
        }
    }
    
    public void ShowVictory()
    {
        // Show the victory panel
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
            Time.timeScale = 0f; // Pause the game
            Debug.Log("Victory!");
        }
    }
    
    public void RestartGame()
    {
        Time.timeScale = 1f; // Unpause the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload current scene
        Debug.Log("Restarting game...");
    }
    
    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Unpause the game
        SceneManager.LoadScene("StartGame"); // Load main menu
        Debug.Log("Loading main menu...");
    }

    // Put other things like quit game here
}