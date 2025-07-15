using UnityEngine;

public class TriggerCinematic : MonoBehaviour
{
    public Cutscene cinematic; 
    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayed)
        {
            if (cinematic != null)
            {
                cinematic.Play(); 
                hasPlayed = true;
                Debug.Log("Cinemática iniciada desde trigger.");
            }
            else
            {
                Debug.LogWarning("No se asignó una cinemática.");
            }
        }
    }
}
