using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Dialogue : MonoBehaviour
{
    [SerializeField] RunDialogue Dialogue;
    bool DialogueWasShown;
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && DialogueWasShown == false)
        {
            
                Dialogue.Dialogue();

                DialogueWasShown = true;
            //si el dialogo ya se mostró activar una funcion q haga q no se vuelva a mostrar o algo q esté en el script de rundialogue maybe?? -ori
        }
    }
}
