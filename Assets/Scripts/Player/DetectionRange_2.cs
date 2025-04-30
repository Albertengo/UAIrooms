using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionRange_2 : MonoBehaviour
{
    [SerializeField] Transform Origin;
    RaycastHit hit;
    public float hitRange;

    public void InteractionInRange()
    {
        if (Physics.Raycast(Origin.position, Origin.right, out hit, hitRange, this.gameObject.GetComponent<PlayerInteraction_2/*PlayerInteraction*/>().Interaction_Layer)) //(hit.collider != null)
        {
            //hit.collider.GetComponent<Enemies>()?.recibirDaño(); //acá lo cambiamos con una funcion q se tenga de NPC para activar dialogo o agarrar objeto
            //GetComponent<PlayerAttack>().detected = true;
            Debug.Log("Interactuando");
        }
    }
}
