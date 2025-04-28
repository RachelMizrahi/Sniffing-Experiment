using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject startPanel; // The opening screen panel

    public void OnStartButtonClicked()
    {
        startPanel.SetActive(false); // Hides the opening screen
        // Here you can trigger other functions that start the game
    }
}