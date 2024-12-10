using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public GameObject winScreen;  // Reference to the Win UI

    public void ShowWinScreen()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0; // Pause the game when the win screen is active
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
        Time.timeScale = 1; // Reset time scale to normal
        SceneManager.LoadScene("MainMenu"); // Load the MainMenu scene
    }
}
