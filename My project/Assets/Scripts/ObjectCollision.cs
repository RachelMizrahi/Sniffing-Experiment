using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    public AudioSource correctSound;  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Answer"))
        {
            if (correctSound != null)
            {
                correctSound.Play();
            }
        }
    }
}