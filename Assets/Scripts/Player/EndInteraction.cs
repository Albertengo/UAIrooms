using UnityEngine;

public class EndInteraction : MonoBehaviour
{
    static public bool Interacting;
    public void end_Interaction()
    {
        Interacting = false;
        Debug.Log("Interaccion terminada");
    }
}
