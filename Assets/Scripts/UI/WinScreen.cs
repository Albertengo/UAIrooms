using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    public GameObject VictoryScreen;

    private SpawnEnemy Enemy;
    private void Start()
    {
        VictoryScreen.SetActive(false);
    }
    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Enemy.hasSpawned == false) return;

        if (other.CompareTag("Player"))
        {
            Debug.Log("Colisionando");
            if (VictoryScreen != null && Enemy.hasSpawned == true)
            {
                VictoryScreen.SetActive(true);
                Debug.Log("Escapaste");
            }

        }
    }
}
