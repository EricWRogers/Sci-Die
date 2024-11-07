using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject winScreen; // Assign the Win Screen UI in the Inspector
    public GameObject loseScreen; // Assign the Lose Screen UI in the Inspector
    public GameObject hud; // Assign the entire HUD UI object here
    public Health playerHealth; // Reference to the Player's Health script

    private bool gameEnded = false;

    void Start()
    {
        playerHealth.outOfHealth.AddListener(ShowLoseScreen); // Subscribe to the player's outOfHealth event
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
        loseScreen.SetActive(false);
        hud.SetActive(false); // Hide the entire HUD
        Time.timeScale = 0f; // Optional: Stop game time
    }

    public void ShowLoseScreen()
    {
        if (gameEnded) return;

        gameEnded = true;
        loseScreen.SetActive(true);
        winScreen.SetActive(false);
        hud.SetActive(false); // Hide the entire HUD
        Time.timeScale = 0f; // Optional: Stop game time
    }

    // Call this method to reset the game if needed
    public void ResetGame()
    {
        gameEnded = false;
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        hud.SetActive(true); // Show the HUD again
        Time.timeScale = 1f;
    }
}
