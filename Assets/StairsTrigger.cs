using UnityEngine;

public class StairsTrigger : MonoBehaviour
{

    public Transform teleportPoint;
    private bool triggered = false;




    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;
            TeleportPlayer(other.gameObject);
        }
    }

    void TeleportPlayer(GameObject player)
    {
        if (teleportPoint != null)
        {
            player.transform.position = teleportPoint.position;
            Debug.Log("se teletransporto al primer piso");
        }
        else
        {
            Debug.LogWarning("el punto de teletransporte no esta asignado");
        }
    }
}