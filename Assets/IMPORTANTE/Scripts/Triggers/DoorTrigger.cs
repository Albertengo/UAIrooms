using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform enemySpawnPoint;
    private bool playerInside = false;
    private bool enemySpawned = false;

    [Header("Puerta desbloqueable")]
    //public Animator doorAnimator;
    public Collider doorCollider; // Collider que bloquea el paso
    private bool isUnlocked = false;

    public GameObject exitPanel;

    private bool endTriggered = false;
    private bool sawNote = false;

    void Start()
    {
            exitPanel.SetActive(false);
    }


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
        if (other.CompareTag("Player") && enemySpawned && sawNote && !endTriggered)
        {
            playerInside = false;
            ShowExitPanel();
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

    public void UnlockDoor()
    {
        if (isUnlocked) return;

        isUnlocked = true;

        //if (doorAnimator != null)
        //{
        //    doorAnimator.SetTrigger("Open");
        //}

        if (doorCollider != null)
        {
            doorCollider.enabled = false;
        }

        Debug.Log("Puerta desbloqueada");
    }
    void ShowExitPanel()
    {
        if (exitPanel != null)
        {
            exitPanel.SetActive(true);
            Time.timeScale = 0f; // Pausa el juego
            endTriggered = true;
            Debug.Log("demo terminada");
        }
    }
    public void SetInteractionComplete()
    {
        sawNote = true;
        Debug.Log("vio la nota");
    }
}

