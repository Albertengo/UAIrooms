using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    private bool isPlayerInside = false;
    private EnemyMovement enemy;

 

    void Update()
    {
        if (enemy == null)
        {
            enemy = FindObjectOfType<EnemyMovement>();
            if (enemy != null)
            {
                Debug.Log("enemigo encontrado");
            }
        }
        if (enemy != null && isPlayerInside && Input.GetKeyDown(KeyCode.F))
        {
            enemy.StopChasingAndWait();

            Debug.Log("el enemigo se detuvo");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            enemy.ResumePatrolling();
            Debug.Log("enemigo patrulla");
        }
    }
}
