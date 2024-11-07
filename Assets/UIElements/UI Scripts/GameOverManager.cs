using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject hud;
    public Health playerHealth;

    private bool gameEnded = false;

    void Start()
    {
        playerHealth.outOfHealth.AddListener(ShowLoseScreen); // Subscribe to player health
    }

    // Called by enemies when they are defeated
    public void CheckWinCondition()
    {
        GameObject[] remainingEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (remainingEnemies.Length == 0)
        {
            ShowWinScreen();
        }
    }

    public void ShowWinScreen()
    {
        if (gameEnded) return;

        gameEnded = true;
        winScreen.SetActive(true);
        hud.SetActive(true);
        Time.timeScale = 0f; // Pause game
    }

    public void ShowLoseScreen()
    {
        if (gameEnded) return;

        gameEnded = true;
        loseScreen.SetActive(true);
        hud.SetActive(true);
        Time.timeScale = 0f; // Pause game
    }

    // Retry button functionality
    public void RetryGame()
    {
        Time.timeScale = 1f; // Unpause game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload current scene
    }

    // Quit button functionality
    public void QuitGame()
    {
        Application.Quit(); // Closes the game application
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in the editor
        #endif
    }
}
