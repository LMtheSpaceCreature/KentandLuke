using UnityEngine;

public class VictoryTrigger : MonoBehaviour
{
    void OnDestroy()
    {
        // Only trigger if game is still running (not quitting)
        if (Application.isPlaying && gameObject.scene.isLoaded)
        {
            Debug.Log("Boss destroyed! Showing victory!");
            GameOverManager gom = FindObjectOfType<GameOverManager>();
            if (gom != null)
            {
                gom.ShowVictory();
            }
        }
    }
}