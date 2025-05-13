using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject startScreenCanvas;
    public GameObject gameContent;

    void Start()
    {
        startScreenCanvas.SetActive(true);
        gameContent.SetActive(false);
    }

    public void onStartButtonClicked()
    {
        startScreenCanvas.SetActive(false);
        gameContent.SetActive(true);
    }
}