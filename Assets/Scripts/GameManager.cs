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

        pauseMenu.SetActive(false);
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
