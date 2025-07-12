using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform enemySpawnPoint;
    private bool playerInside = false;
    private bool enemySpawned = false;

    void Update()
    {
        if (playerInside && !enemySpawned && Input.GetKeyDown(KeyCode.F))
        {
            SpawnEnemy();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefab != null && enemySpawnPoint != null)
        {
            Instantiate(enemyPrefab, enemySpawnPoint.position, enemySpawnPoint.rotation);
            enemySpawned = true;
            Debug.Log("¡Enemigo spawneado!");
        }
        else
        {
            Debug.LogWarning("Falta asignar el prefab del enemigo o el punto de spawn.");
        }
    }
}
