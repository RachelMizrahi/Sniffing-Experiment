using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectGameManager : MonoBehaviour
{
    public List<GameObject> objectsToSpawn;  // List of objects to spawn
    public GameObject currentObject;         // The current object being held by the player
    public AudioSource correctSound;         // Audio to play when any answer is touched
    public TMP_Text questionText;
    public TMP_Text timerText;                   // Text to display the timer
    public TMP_Text answer1Text;            // Answer1 text
    public TMP_Text answer2Text;            // Answer2 text
    public TMP_Text endGameText;
    public float objectLifeTime = 10f;       // Time before the object disappears
    public float waitTimeBetweenObjects = 10f; // Time to wait before the next object appears
    private float timer;                     // Timer for counting down the object life time
    private bool isTimerRunning = false;     // Flag to check if the timer is running
    private int currentObjectIndex = 0;     // Index to track the current object
    private int objectCounter = 0;       // Counter to track the number of displayed objects

    private void Start()
    {
        StartNewObject(); // Start the first object
    }

    private void Update()
    {
        // Timer functionality
        if (isTimerRunning)
        {
            timer -= Time.deltaTime;
            timerText.text = Mathf.Ceil(timer).ToString(); // Update timer display

            if (timer <= 0f)
            {
                isTimerRunning = false;
                RemoveCurrentObject(); // Remove object when time is up
                StartCoroutine(WaitBeforeNextObject()); // Wait before spawning next object
            }
        }
    }
    // Function to start the game with a new object
    private void StartNewObject()
    {
        // Check if we have more objects to show
        if (currentObjectIndex < objectsToSpawn.Count)
        {
            // Select the object based on the current index
            currentObject = Instantiate(objectsToSpawn[currentObjectIndex], new Vector3(0, 0.8f, 0.4f), Quaternion.identity);

            // Start the timer for this object
            timer = objectLifeTime;
            isTimerRunning = true;

            // Increment the index to point to the next object in the list
            currentObjectIndex++;

            // Increase the object counter
            objectCounter++;

            // Every 12 objects, change the answers
            if (objectCounter % 12 == 0)
            {
                ChangeAnswers();
            }
        }
        else
        {
            // show a message of end game
            EndGame();
        }
    }
    // Function to remove the current object (when time is up)
    private void RemoveCurrentObject()
    {
        if (currentObject != null)
        {
            Destroy(currentObject);  // Destroy the current object
        }
    }

    // Coroutine to wait before spawning the next object
    private IEnumerator WaitBeforeNextObject()
    {
        yield return new WaitForSeconds(waitTimeBetweenObjects);  // Wait for the specified time
        StartNewObject(); // Spawn the next object
    }

    // Function to change the answers
    private void ChangeAnswers()
    {
        if (objectCounter / 12 == 1)
        {
            answer1Text.text = "LIGHT";
            answer2Text.text = "HEAVY";
        }

        if (objectCounter / 12 == 2)
        {
            answer1Text.text = "NATURAL";
            answer2Text.text = "ARTIFICIAL";
        }

        if (objectCounter / 12 == 3)
        {
            answer1Text.text = "HARD";
            answer2Text.text = "SOFT";
        }

        if (objectCounter / 12 == 4)
        {
            answer1Text.text = "SMALL";
            answer2Text.text = "LARGE";
        }

        if (objectCounter / 12 == 5)
        {
            answer1Text.text = "CHEAP";
            answer2Text.text = "EXPENSIVE";
        }

        if (objectCounter / 12 == 6)
        {
            answer1Text.text = "INEDIBLE";
            answer2Text.text = "EDIBLE";
        }

        if (objectCounter / 12 == 7)
        {
            answer1Text.text = "INEDIBLE";
            answer2Text.text = "EDIBLE";
        }
    }

    private void EndGame()
    {
        isTimerRunning = false;
        answer1Text.gameObject.SetActive(false);
        answer2Text.gameObject.SetActive(false);
        questionText.gameObject.SetActive(false);

        endGameText.gameObject.SetActive(true);

        timerText.text = "";
    }

}