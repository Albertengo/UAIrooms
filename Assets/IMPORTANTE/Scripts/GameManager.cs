using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    [Header("SCENE MANAGEMENT")]
    [SerializeField] int SceneNumber;

    [Header("PAUSE")]
    [SerializeField] GameObject pauseMenu;
    private bool isPaused = false;



    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

       
    }

    void Start()
    {
        pauseMenu.SetActive(false);
        HideMouse();
    }

    private void Update()
    {
        PauseGame();
    }



    public void GameOver()
    {
        Debug.Log("Perdiste");
        SceneManager.LoadScene(SceneNumber); //resetear escena actual
    }
    public void Win()
    {
        Debug.Log("Ganaste");
    }



    void HideMouse()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }



    void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (isPaused==false)
            {
                PauseState(true, 0);
            }
            else
                PauseState(false, 1);
        }
    }

    void PauseState(bool pauseState, int timeScale)
    {
        pauseMenu.SetActive(pauseState);
        Time.timeScale = timeScale;
        isPaused = pauseState;
    }
}
