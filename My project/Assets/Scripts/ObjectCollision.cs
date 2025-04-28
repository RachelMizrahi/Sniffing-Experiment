using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    public AudioSource correctSound;  // יוזן מבחוץ

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