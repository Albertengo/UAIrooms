using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
  
    public GameObject enemyPrefab;

    public bool hasSpawned = false;
    public Transform spawnPoint;

    public GameObject EscapeText;

    private void Start()
    {
        EscapeText.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (hasSpawned) return;

        if (other.CompareTag("Player"))
        {
            if (enemyPrefab != null && spawnPoint != null)
            {
                Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
                EscapeText.SetActive(true);
                hasSpawned = true; 
            }

        }
    }
}
