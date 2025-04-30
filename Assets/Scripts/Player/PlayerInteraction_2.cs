using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction_2 : MonoBehaviour
{
    public LayerMask Interaction_Layer;
    [SerializeField] InputActionReference Interaction_Input;
    public DetectionRange_2 Detection;
    public Animator Animator;

    void Start()
    {
        Interaction_Input.action.performed += Interaction;
    }

    void Update()
    {
        if (EndInteraction.Interacting == false)
            ActualizarAnimacion();
    }

    private void Interaction(InputAction.CallbackContext obj)
    {
        Detection.InteractionInRange();
        Debug.Log("Pressing F");
        //Animator.Play("Attack");
        EndInteraction.Interacting = true; //se podria activar un canvas maybe
    }
    void ActualizarAnimacion() //no sé si realmente necesitamos esto pero lo dejo x las dudas hasta q lo tengamos + claro -ori
    {
        //Animator.Play("Running");
        //capaz cerrar canvas
    }
}
