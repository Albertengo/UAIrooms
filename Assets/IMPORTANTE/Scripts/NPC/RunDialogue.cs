using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class RunDialogue : MonoBehaviour
{
    // a reference to the "press e to start" label
    //[SerializeField] GameObject helpOverlay;
    [SerializeField] string StartNode;

    public void Dialogue()
    {
        var runner = FindObjectOfType<DialogueRunner>();
        if (runner != null)
        {
            if (!runner.IsDialogueRunning)
            {
                //helpOverlay.SetActive(false);
                runner.StartDialogue(StartNode);
            }
        }
    }
    //void para lo de q no se vuelva a mostyrar el dialogo o algo asi jeje fijate si te sirve desp
    //public void 

}
