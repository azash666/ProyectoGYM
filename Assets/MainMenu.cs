using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayGame() {
        GameController.numVivos = 10;
        GameController.numZombies = 10;
        SceneManager.LoadScene("main");
    }

    public void QuitGame() {
        Debug.Log("Saliendo del juego");
        Application.Quit();
    }
}
