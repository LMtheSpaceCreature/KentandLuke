using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    
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
    
    public void RestartGame()
    {
        Time.timeScale = 1f; // Unpause the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload current scene
        Debug.Log("Restarting game...");
    }

    // Put other things like quit game here
}