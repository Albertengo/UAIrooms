using UnityEngine;

public class UnlockedDoor : MonoBehaviour
{
    public Collider doorCollider;       
    public GameObject doorVisual;      

    private bool isNear = false;
    private bool doorOpened = false;

    void Update()
    {
        if (isNear && !doorOpened && Input.GetKeyDown(KeyCode.F))
        {
            doorOpened = true;
            UnlockDoor();
        }
    }

    private void UnlockDoor()
    {
        if (doorCollider != null)
            doorCollider.enabled = false;

        if (doorVisual != null)
            doorVisual.SetActive(false); 

        Debug.Log("Puerta desbloqueada y oculta.");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isNear = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isNear = false;
    }
}
