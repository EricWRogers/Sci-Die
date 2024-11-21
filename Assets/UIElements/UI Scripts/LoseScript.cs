using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScript : MonoBehaviour
{
    public GameObject loseScreen;  // Reference to the Lose UI

    public void ShowLoseScreen()
    {
        loseScreen.SetActive(true);
        Time.timeScale = 0; // Pause the game when the lose screen is active
    }

    // Method to restart the game
    public void RetryGame()
    {
        Time.timeScale = 1; // Reset time scale to normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload current scene
    }

    // Method to quit the game
    public void QuitGame()
    {
        Application.Quit(); // Close the application
    }
}
