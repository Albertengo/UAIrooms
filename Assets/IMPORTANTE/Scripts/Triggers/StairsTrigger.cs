using UnityEngine;

public class StairsTrigger : MonoBehaviour
{
    public Transform teleportPoint;
    public float cooldownTime = 1f;

    private bool isInside = false;
    private static bool isInCooldown = false; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isInside && !isInCooldown)
        {
            isInside = true;
            TeleportPlayer(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInside = false;
        }
    }

    void TeleportPlayer(GameObject player)
    {
        if (teleportPoint != null)
        {
            isInCooldown = true;
            player.transform.position = teleportPoint.position;
            Debug.Log("Se teletransportó");

            Invoke(nameof(ResetCooldown), cooldownTime);
        }
        else
        {
            Debug.LogWarning("No se asignó el punto de teletransporte");
        }
    }

    void ResetCooldown()
    {
        isInCooldown = false;
    }
}
