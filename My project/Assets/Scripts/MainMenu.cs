using UnityEngine;
using UnityEngine.SceneManagement;  

public class MainMenu : MonoBehaviour
{
    // This function is called when the player clicks the "Start" button
    public void StartGame()
    {
        // Load the game scene
        SceneManager.LoadScene("GameScene");
    }
}