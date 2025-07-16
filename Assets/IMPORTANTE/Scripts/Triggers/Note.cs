using UnityEngine;

public class Note : MonoBehaviour
{
    public GameObject noteUI; 
    private bool isPlayerNear = false;
    private bool isNoteOpen = false;

    void Update()
    {
        if (isPlayerNear)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (!isNoteOpen)
                    OpenNote();
                else
                    CloseNote();
            }
        }
    }
    public void CheckNote()
    {
        if (!isNoteOpen)
        {
            OpenNote();
        }
        else
            CloseNote();
    }
    private void OpenNote()
    {
        noteUI.SetActive(true);
        isNoteOpen = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }
    private void CloseNote()
    {
        noteUI.SetActive(false);
        isNoteOpen = false;
        Time.timeScale = 1f; 
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        FindObjectOfType<DoorTrigger>().SetInteractionComplete();


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }
}
