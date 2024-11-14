using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject winScreen; // Assign the HUD's WinScreen child here
    public GameObject loseScreen; // Assign the HUD's LoseScreen child here
    public GameObject healthBar; // Assign the Health Bar in the HUD here

    // Call this method when the player wins
    public void ShowWinScreen()
    {
        winScreen.SetActive(true);
        loseScreen.SetActive(false);
        healthBar.SetActive(false);
        Time.timeScale = 0f;
    }

    // Call this method when the player loses
    public void ShowLoseScreen()
    {
        loseScreen.SetActive(true);
        winScreen.SetActive(false);
        healthBar.SetActive(false);
        Time.timeScale = 0f;
    }

    // Call this method to reset the screens and resume the game
    public void ResetGame()
    {
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        healthBar.SetActive(true);
        Time.timeScale = 1f;
    }
}
