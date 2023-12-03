using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public string Game;
    public string Tutorial;
    public string Credits;

    // Métodos para cambiar entre pantallas
    public void GoToGame()
    {
        SceneManager.LoadScene(Game);
    }

    public void GoToTutorial()
    {
        SceneManager.LoadScene(Tutorial);
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene(Credits);
    }

    // Método para salir del juego
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
