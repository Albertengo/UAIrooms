using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    public Transform destination; 
    public string playerTag = "Player";
    public string enemyTag = "Enemy";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag) || other.CompareTag(enemyTag))
        {
            other.transform.position = destination.position;
        }
    }
}
