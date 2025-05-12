using UnityEngine;
using UnityEngine.SceneManagement;

namespace interfaz
{
    public class Buttons : MonoBehaviour
    {
        //lógica para los botones usados dentro del juego
        //[SerializeField] GameObject PanelCreditos;
        //[SerializeField] GameObject PanelOpciones;
        [SerializeField] int Escena;

        public void Menu()
        {
            SceneManager.LoadScene("Menu");
        }
        public void PlayButton()
        {
            //Prob vamos a tener q hacer algo asi desp asi q no lo saco x ahora -ori
            //PlayerPrefs.SetInt("MaxCombo", 0);
            SceneManager.LoadScene(Escena);//("Game");
            Time.timeScale = 1f;
        }

        public void QuitGame()
        {
            Debug.Log("Saliste.");
            Application.Quit();
        }
        public void Credits()
        {
            //PanelCreditos.SetActive(true);s
        }
        public void Options()
        {
            //PanelOpciones.SetActive(true);
        }
    }
}
