using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    private bool hasSpawned = false;


    public void Spawn()
    {
        if (enemyPrefab != null && spawnPoint != null)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            Debug.Log("enemigo spawneado");
            hasSpawned = true;
        }
        else
        {
            Debug.LogWarning("Falta asignar el prefab o spawn point");
        }
    }
}
