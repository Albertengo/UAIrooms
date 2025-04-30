using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
  
    public GameObject enemyPrefab;

    private bool hasSpawned = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasSpawned) return;

        if (other.CompareTag("Player"))
        {
            if (enemyPrefab != null)
            {
                Instantiate(enemyPrefab, transform.position, transform.rotation);
                hasSpawned = true; 
            }
            else
            {
                Debug.LogWarning("no hay enemy prefab");
            }
        }
    }
}
