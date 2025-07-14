using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Dialogue : MonoBehaviour
{
    [SerializeField] RunDialogue Dialogue;
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Dialogue.Dialogue();
        }
    }
}
