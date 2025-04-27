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
    public TMP_Text timerText;                   // Text to display the timer
    public float objectLifeTime = 10f;       // Time before the object disappears
    public float waitTimeBetweenObjects = 10f; // Time to wait before the next object appears
    private float timer;                     // Timer for counting down the object life time
    private bool isTimerRunning = false;     // Flag to check if the timer is running
    private int currentObjectIndex = 0;     // Index to track the current object

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
            currentObject = Instantiate(objectsToSpawn[currentObjectIndex], new Vector3(0, 0.65f, 0.5f), Quaternion.identity);

            // Start the timer for this object
            timer = objectLifeTime;
            isTimerRunning = true;

            // Increment the index to point to the next object in the list
            currentObjectIndex++;
        }
        else
        {
            // Stop the game or show a message
            Debug.Log("All objects displayed, ending the game.");
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

    // Function that gets called when the object touches any answer
    private void OnTriggerEnter(Collider other)
    {
        // If the object touches any "Answer" (box collider tagged as "Answer")
        if (other.CompareTag("Answer"))
        {
            // Play the correct sound
            if (correctSound != null)
            {
                correctSound.Play();
            }
        }
    }
}