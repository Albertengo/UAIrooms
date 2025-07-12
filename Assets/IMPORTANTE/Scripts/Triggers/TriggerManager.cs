using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class TriggerManager : MonoBehaviour
{
    //public string nodeName;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            //FindObjectOfType<DialogueRunner>().StartDialogue(nodeName);
            Debug.Log("ir a las escaleras");
        }
    }
}

