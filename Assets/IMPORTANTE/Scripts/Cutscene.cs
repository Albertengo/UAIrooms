using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cutscene : MonoBehaviour
{
    public Image[] images;
    public GameObject cinematicPanel;

    public bool loadSceneAtEnd = false; // solo en la cinemática inicial
    public string sceneToLoad = "Level1Scene";

    private int currentImageIndex = 0;

    public delegate void CinematicEndDelegate();
    public event CinematicEndDelegate OnCinematicEnd;

    void Start()
    {
        if (cinematicPanel != null)
            cinematicPanel.SetActive(true);

        Time.timeScale = 0f;

        foreach (Image img in images)
            img.gameObject.SetActive(false);

        if (images.Length > 0)
            images[0].gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentImageIndex++;
            ShowNextImage();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            SkipCutscene();
        }
    }

    void ShowNextImage()
    {
        if (currentImageIndex >= images.Length)
        {
            EndCinematic();
            return;
        }

        for (int i = 0; i < images.Length; i++)
            images[i].gameObject.SetActive(i <= currentImageIndex);
    }

    void EndCinematic()
    {
        Time.timeScale = 1f;

        if (loadSceneAtEnd)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            gameObject.SetActive(false);
            OnCinematicEnd?.Invoke();
        }
    }

    void SkipCutscene()
    {
        EndCinematic();
    }

    public void Play()
    {
        gameObject.SetActive(true);
        currentImageIndex = 0;
        Time.timeScale = 0f;

        foreach (Image img in images)
            img.gameObject.SetActive(false);

        if (images.Length > 0)
            images[0].gameObject.SetActive(true);
    }
}
