using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    //Agregar script en jugador

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject spawn;
    [SerializeField] string eventName;


    private void OnTriggerEnter(Collider other) 
    {
        switch (eventName)
        {
            case "Spawn": Instantiate(enemyPrefab, spawn.transform.position, Quaternion.identity);
                break;

            case "Exit": GameManager.instance.Win();
                break;
        }
    }
}
