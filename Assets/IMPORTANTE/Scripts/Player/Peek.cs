using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peek : MonoBehaviour
{
    //Logicamente lo q se puede hacer para esta mecánica es que si se aprieta Q/E se reproduzca una animacion de la cámara
    //que solo se reproduzca cuando estás quieto, si no, no (para evitar bugs)
    
    // Start is called before the first frame update

    public Animator cameraAnimator;
    public Transform player;
    public float stopThreshold = 0.1f;
    public Rigidbody playerRB;

    void Update()
    {
       
        if (IsPlayerStill())
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                cameraAnimator.SetTrigger("LeanLeft");
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                cameraAnimator.SetTrigger("LeanRight");
            }
        }
    }

    bool IsPlayerStill()
    {
        return playerRB.velocity.magnitude < stopThreshold;
    }
}


