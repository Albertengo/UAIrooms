using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

//NOTA: no funciona que se frezee el player cuando se reproduce el diálogo...

public class RunDialogue : MonoBehaviour
{
    // a reference to the "press e to start" label
    //[SerializeField] GameObject helpOverlay;
    [SerializeField] string StartNode;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        //PlayerMovement playerMov = player.GetComponent<PlayerMovement>();
    }
    public void Dialogue()
    {
        var runner = FindObjectOfType<DialogueRunner>();
        if (runner != null)
        {
            if (!runner.IsDialogueRunning)
            {
                //FindObjectOfType<PlayerMovement>().DontMove();
                //player = FindObjectOfType<PlayerMovement>().DontMove();

                
                //if (player != null)
                //{
                    
                        GetComponent<PlayerMovement>()?.FreezePlayer();
                        runner.StartDialogue(StartNode);
                //}

                //helpOverlay.SetActive(false);
                
            }
            else 
            {
                GetComponent<PlayerMovement>()?.UnfreezePlayer();
            }

        }
    }
    //void para lo de q no se vuelva a mostyrar el dialogo o algo asi jeje fijate si te sirve desp
    //public void 

}
